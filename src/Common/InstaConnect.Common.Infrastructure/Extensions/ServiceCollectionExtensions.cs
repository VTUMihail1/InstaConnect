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
    public static IServiceCollection AddUnitOfWork(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

        return serviceCollection;
    }

    public static IServiceCollection AddObservability(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        IWebHostEnvironment webHostEnvironment)
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
                  .AddOtlpExporter(options =>
                  {
                      options.Endpoint = new Uri(openTelemetryOptions.Endpoint);
                  }))
              .WithMetrics(metrics => metrics
                  .AddAspNetCoreInstrumentation()
                  .AddHttpClientInstrumentation()
                  .AddMassTransitInstrumentation()
                  .AddOtlpExporter(options =>
                  {
                      options.Endpoint = new Uri(openTelemetryOptions.Endpoint);
                  }));

        return serviceCollection;
    }

    public static IServiceCollection AddMongoDbContext(this IServiceCollection serviceCollection)
    {
        const string ConventionName = "ApplicationConventionPack";

        serviceCollection
            .AddOptions<MongoDatabaseOptions>()
            .BindConfiguration(nameof(MongoDatabaseOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        serviceCollection.AddScoped<IMongoClient>(sp => new MongoClient(sp.GetRequiredService<IOptions<MongoDatabaseOptions>>()
                                                                          .Value
                                                                          .ConnectionString));

        serviceCollection.AddScoped(sp => sp.GetRequiredService<IMongoClient>()
                                            .GetDatabase(sp.GetRequiredService<IOptions<MongoDatabaseOptions>>()
                                                           .Value
                                                           .Name));

        serviceCollection
            .AddScoped<IPaginator, Paginator>()
            .AddScoped<IMongoDbContext, MongoDbContext>();

        var conventionPack = new ConventionPack
        {
            new SnakeCaseElementNameConvention(),
            new IgnoreExtraElementsConvention(true)
        };

        ConventionRegistry.Register(
            ConventionName,
            conventionPack,
            t => true
        );

        return serviceCollection;
    }

    public static IServiceCollection AddRedisCaching(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection
            .AddOptions<CacheOptions>()
            .BindConfiguration(nameof(CacheOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var cacheOptions = configuration
            .GetSection(nameof(CacheOptions))
            .Get<CacheOptions>()!;

        serviceCollection
            .AddScoped<IJsonConverter, JsonConverter>()
            .AddScoped<ICacheHandler, CacheHandler>()
            .AddScoped<ICacheRequestFactory, CacheRequestFactory>();

        serviceCollection.AddStackExchangeRedisCache(redisOptions =>
            redisOptions.Configuration = cacheOptions.ConnectionString);

        serviceCollection
            .AddHealthChecks()
            .AddRedis(cacheOptions.ConnectionString);

        return serviceCollection;
    }

    public static IServiceCollection AddRabbitMQ(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        Assembly currentAssembly,
        Action<IBusRegistrationConfigurator>? configure = null
        )
    {
        serviceCollection
            .AddOptions<MessageBrokerOptions>()
            .BindConfiguration(nameof(MessageBrokerOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var messageBrokerOptions = configuration
            .GetSection(nameof(MessageBrokerOptions))
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

        serviceCollection
            .AddScoped<IEventPublisher, EventPublisher>();

        return serviceCollection;
    }

    public static IServiceCollection AddJwtBearer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddScoped<IEncoder, Encoder>();

        serviceCollection
        .AddOptions<SessionTokenOptions>()
        .BindConfiguration(nameof(SessionTokenOptions))
        .ValidateDataAnnotations()
        .ValidateOnStart();

        var accessTokenOptions = configuration
            .GetSection(nameof(SessionTokenOptions))
            .Get<SessionTokenOptions>()!;

        serviceCollection
            .AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                var encoder = serviceCollection
                                 .BuildServiceProvider()
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

    public static IServiceCollection AddCloudinary(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddOptions<ImageUploadOptions>()
            .BindConfiguration(nameof(ImageUploadOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var imageUploadOptions = configuration
            .GetSection(nameof(ImageUploadOptions))
            .Get<ImageUploadOptions>()!;

        serviceCollection.AddScoped(_ => new Cloudinary(new Account(
            imageUploadOptions.CloudName,
            imageUploadOptions.ApiKey,
            imageUploadOptions.ApiSecret)));

        serviceCollection
            .AddScoped<IImageUploadFactory, ImageUploadFactory>()
            .AddScoped<IImageHandler, ImageHandler>();

        return serviceCollection;
    }

    public static IServiceCollection AddDateTimeProvider(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IDateTimeProvider, DateTimeProvider>();

        return serviceCollection;
    }

    public static IServiceCollection AddGuidProvider(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IGuidProvider, GuidProvider>();

        return serviceCollection;
    }

    public static TOptions AddOptions<TOptions>(this IServiceCollection serviceCollection, IConfiguration configuration, string sectionName)
        where TOptions : class
    {
        serviceCollection
            .AddOptions<TOptions>()
            .BindConfiguration(sectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var options = configuration
            .GetSection(sectionName)
            .Get<TOptions>()!;

        return options;
    }

    public static IServiceCollection AddSortOrders(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<ISortOrdererFactory, SortOrdererFactory>()
            .AddImplementationsOf<ISortOrderer>(CommonInfrastructureReference.Assembly);

        return serviceCollection;
    }
}
