using System.Reflection;

using CloudinaryDotNet;

using InstaConnect.Common.Application.Helpers;
using InstaConnect.Common.Domain.Abstractions;
using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Events.Abstractions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Common.Infrastructure.Helpers;
using InstaConnect.Common.Infrastructure.Helpers.Conventions;
using InstaConnect.Common.Infrastructure.Helpers.SortOrders;
using InstaConnect.Common.Infrastructure.Models.Options;

using MassTransit;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static partial class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddUnitOfWork()
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            return serviceCollection;
        }

        public IServiceCollection AddObservability(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            serviceCollection
                .AddOptions<OpenTelemetryOptions>()
                .BindConfiguration(OpenTelemetryOptions.SectionName)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            var openTelemetryOptions = configuration
                        .GetSection(OpenTelemetryOptions.SectionName)
                        .Get<OpenTelemetryOptions>()!;

            serviceCollection.AddOpenTelemetry()
                  .ConfigureResource(r => r.AddService(webHostEnvironment.ApplicationName))
                  .WithTracing(tracing => tracing
                      .AddAspNetCoreInstrumentation()
                      .AddHttpClientInstrumentation()
                      .AddRedisInstrumentation()
                      .AddMassTransitInstrumentation()
                      .AddOtlpExporter(options => options.Endpoint = new Uri(openTelemetryOptions.Endpoint)))
                  .WithMetrics(metrics => metrics
                      .AddAspNetCoreInstrumentation()
                      .AddHttpClientInstrumentation()
                      .AddMassTransitInstrumentation()
                      .AddOtlpExporter(options => options.Endpoint = new Uri(openTelemetryOptions.Endpoint)));

            return serviceCollection;
        }

        public IServiceCollection AddMongoDbContext()
        {
            const string ConventionName = "ApplicationConventionPack";

            serviceCollection
                .AddOptions<MongoDatabaseOptions>()
                .BindConfiguration(MongoDatabaseOptions.SectionName)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            serviceCollection.AddScoped<IMongoClient>(sp =>
                new MongoClient(sp.GetRequiredService<IOptions<MongoDatabaseOptions>>().Value.ConnectionString));

            serviceCollection.AddScoped(sp =>
                sp.GetRequiredService<IMongoClient>()
                  .GetDatabase(sp.GetRequiredService<IOptions<MongoDatabaseOptions>>().Value.Name));

            serviceCollection.AddScoped<IPaginator, Paginator>()
                             .AddScoped<IMongoDbContext, MongoDbContext>();

            var conventionPack = new ConventionPack
            {
                new SnakeCaseElementNameConvention(),
                new IgnoreExtraElementsConvention(true)
            };

            ConventionRegistry.Register(ConventionName, conventionPack, t => true);

            return serviceCollection;
        }

        public IServiceCollection AddRedisCaching(IConfiguration configuration)
        {
            serviceCollection
                .AddOptions<CacheOptions>()
                .BindConfiguration(CacheOptions.SectionName)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            var cacheOptions = configuration
                .GetSection(CacheOptions.SectionName)
                .Get<CacheOptions>()!;

            serviceCollection.AddScoped<IJsonConverter, JsonConverter>()
                             .AddScoped<ICacheHandler, CacheHandler>()
                             .AddScoped<ICacheRequestFactory, CacheRequestFactory>();

            serviceCollection.AddStackExchangeRedisCache(redisOptions =>
                redisOptions.Configuration = cacheOptions.ConnectionString);

            serviceCollection.AddHealthChecks()
                             .AddRedis(cacheOptions.ConnectionString);

            return serviceCollection;
        }

        public IServiceCollection AddRabbitMQ(IConfiguration configuration, Assembly currentAssembly, Action<IBusRegistrationConfigurator>? configure = null)
        {
            serviceCollection
                .AddOptions<MessageBrokerOptions>()
                .BindConfiguration(MessageBrokerOptions.SectionName)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            var messageBrokerOptions = configuration
                .GetSection(MessageBrokerOptions.SectionName)
                .Get<MessageBrokerOptions>()!;

            serviceCollection.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();
                busConfigurator.AddConsumers(currentAssembly);

                busConfigurator.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(new Uri(messageBrokerOptions.Host), h =>
                    {
                        h.Username(messageBrokerOptions.Username);
                        h.Password(messageBrokerOptions.Password);
                    });

                    configurator.ConfigureEndpoints(context);
                });

                configure?.Invoke(busConfigurator);
            });

            serviceCollection.AddScoped<IEventPublisher, EventPublisher>();

            return serviceCollection;
        }

        public IServiceCollection AddJwtBearer(IConfiguration configuration)
        {
            serviceCollection.AddScoped<IEncoder, Encoder>();

            serviceCollection.AddOptions<AccessTokenOptions>()
                             .BindConfiguration(AccessTokenOptions.SectionName)
                             .ValidateDataAnnotations()
                             .ValidateOnStart();

            var accessTokenOptions = configuration
                .GetSection(AccessTokenOptions.SectionName)
                .Get<AccessTokenOptions>()!;

            serviceCollection.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                var encoder = serviceCollection.BuildServiceProvider()
                                              .GetRequiredService<IEncoder>();

                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(encoder.GetBytesUTF8(accessTokenOptions.SecurityKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return serviceCollection;
        }

        public IServiceCollection AddCloudinary(IConfiguration configuration)
        {
            serviceCollection
                .AddOptions<ImageUploadOptions>()
                .BindConfiguration(ImageUploadOptions.SectionName)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            var imageUploadOptions = configuration
                .GetSection(ImageUploadOptions.SectionName)
                .Get<ImageUploadOptions>()!;

            serviceCollection.AddScoped(_ => new Cloudinary(new Account(
                imageUploadOptions.CloudName,
                imageUploadOptions.ApiKey,
                imageUploadOptions.ApiSecret)));

            serviceCollection.AddScoped<IImageUploadFactory, ImageUploadFactory>()
                             .AddScoped<IImageHandler, ImageHandler>();

            return serviceCollection;
        }

        public IServiceCollection AddDateTimeProvider()
        {
            serviceCollection.AddScoped<IDateTimeProvider, DateTimeProvider>();
            return serviceCollection;
        }

        public IServiceCollection AddGuidProvider()
        {
            serviceCollection.AddScoped<IGuidProvider, GuidProvider>();
            return serviceCollection;
        }

        public TOptions AddOptions<TOptions>(IConfiguration configuration, string sectionName) where TOptions : class
        {
            serviceCollection.AddOptions<TOptions>()
                             .BindConfiguration(sectionName)
                             .ValidateDataAnnotations()
                             .ValidateOnStart();

            return configuration.GetSection(sectionName).Get<TOptions>()!;
        }

        public IServiceCollection AddSortOrders()
        {
            serviceCollection.AddScoped<ISortOrdererFactory, SortOrdererFactory>()
                             .AddImplementationsOf<ISortOrderer>(CommonInfrastructureReference.Assembly);

            return serviceCollection;
        }
    }
}
