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

        public IServiceCollection AddOpenTelemetry(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            serviceCollection.AddValidatedOptions<OpenTelemetryOptions>(OpenTelemetryOptions.SectionName);
            var options = configuration.GetOptions<OpenTelemetryOptions>(OpenTelemetryOptions.SectionName);

            serviceCollection.AddOpenTelemetry()
                  .ConfigureResource(r => r.AddService(webHostEnvironment.ApplicationName))
                  .WithTracing(t => t
                      .AddAspNetCoreInstrumentation()
                      .AddHttpClientInstrumentation()
                      .AddRedisInstrumentation()
                      .AddMassTransitInstrumentation()
                      .AddOtlpExporter(o => o.Endpoint = new Uri(options.Endpoint)))
                  .WithMetrics(m => m
                      .AddAspNetCoreInstrumentation()
                      .AddHttpClientInstrumentation()
                      .AddMassTransitInstrumentation()
                      .AddOtlpExporter(o => o.Endpoint = new Uri(options.Endpoint)));

            return serviceCollection;
        }

        public IServiceCollection AddMongoDatabase(IConfiguration configuration)
        {
            const string ConventionName = "ApplicationConventionPack";

            serviceCollection.AddValidatedOptions<MongoOptions>(MongoOptions.SectionName);
            var options = configuration.GetOptions<MongoOptions>(MongoOptions.SectionName);

            serviceCollection.AddScoped<IMongoClient>(_ =>
                new MongoClient(options.ConnectionString));

            serviceCollection.AddScoped(sp =>
                sp.GetRequiredService<IMongoClient>()
                  .GetDatabase(options.Name));

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
            serviceCollection.AddValidatedOptions<RedisOptions>(RedisOptions.SectionName);
            var options = configuration.GetOptions<RedisOptions>(RedisOptions.SectionName);

            serviceCollection.AddScoped<IJsonConverter, JsonConverter>()
                             .AddScoped<ICacheHandler, CacheHandler>()
                             .AddScoped<ICacheRequestFactory, CacheRequestFactory>();

            serviceCollection.AddStackExchangeRedisCache(redisOptions =>
                redisOptions.Configuration = options.ConnectionString);

            serviceCollection.AddHealthChecks()
                             .AddRedis(options.ConnectionString);

            return serviceCollection;
        }

        public IServiceCollection AddRabbitMQ(IConfiguration configuration, string prefix, params Assembly[] currentAssemblies)
        {
            serviceCollection.AddValidatedOptions<RabbitMqOptions>(RabbitMqOptions.SectionName);
            var options = configuration.GetOptions<RabbitMqOptions>(RabbitMqOptions.SectionName);

            serviceCollection.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatterWithPrefix(prefix);

                busConfigurator.AddConsumers(currentAssemblies);

                busConfigurator.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(options.ConnectionString);

                    configurator.ConfigureEndpoints(context);
                });
            });

            serviceCollection.AddScoped<IEventPublisher, EventPublisher>();

            return serviceCollection;
        }

        public IServiceCollection AddJwtBearer(IConfiguration configuration)
        {
            serviceCollection.AddValidatedOptions<AccessTokenOptions>(AccessTokenOptions.SectionName);
            var options = configuration.GetOptions<AccessTokenOptions>(AccessTokenOptions.SectionName);

            serviceCollection.AddScoped<IEncoder, Encoder>();

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
                    IssuerSigningKey = new SymmetricSecurityKey(encoder.GetBytesUTF8(options.SecurityKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return serviceCollection;
        }

        public IServiceCollection AddCloudinary(IConfiguration configuration)
        {
            serviceCollection.AddValidatedOptions<CloudinaryOptions>(CloudinaryOptions.SectionName);
            var options = configuration.GetOptions<CloudinaryOptions>(CloudinaryOptions.SectionName);

            serviceCollection.AddScoped(_ => new Cloudinary(new Account(
                options.CloudName,
                options.ApiKey,
                options.ApiSecret)));

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

        public IServiceCollection AddSortOrders()
        {
            serviceCollection.AddScoped<ISortOrdererFactory, SortOrdererFactory>()
                             .AddImplementationsOf<ISortOrderer>(CommonInfrastructureReference.Assembly);

            return serviceCollection;
        }
    }
}
