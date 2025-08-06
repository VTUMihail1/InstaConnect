using System.Reflection;

using CloudinaryDotNet;

using InstaConnect.Common.Application.Helpers;
using InstaConnect.Common.Domain.Abstractions;
using InstaConnect.Common.Extensions;
using InstaConnect.Common.Infrastructure;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Common.Infrastructure.Helpers;
using InstaConnect.Common.Infrastructure.Helpers.SortOrders;
using InstaConnect.Common.Infrastructure.Models.Options;
using InstaConnect.Shared.Infrastructure.Extensions;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace InstaConnect.Shared.Infrastructure.Extensions;
public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddUnitOfWork<TContext>(this IServiceCollection serviceCollection)
    where TContext : DbContext
    {
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>(sp =>
        new UnitOfWork(sp.GetRequiredService<TContext>()));

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
                  .AddEntityFrameworkCoreInstrumentation()
                  .AddSqlClientInstrumentation()
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

    public static IServiceCollection AddDatabaseContext<TContext>(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        Action<DbContextOptionsBuilder>? optionsAction = null)
    where TContext : DbContext
    {
        serviceCollection
            .AddOptions<DatabaseOptions>()
            .BindConfiguration(nameof(DatabaseOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var databaseOptions = configuration
                    .GetSection(nameof(DatabaseOptions))
                    .Get<DatabaseOptions>()!;



        serviceCollection.AddDbContext<TContext>((sp, options) =>
        {
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            options.UseSqlServer(
                    databaseOptions.ConnectionString,
                    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());

            optionsAction?.Invoke(options);
        });

        serviceCollection
            .AddScoped<IPaginator, Paginator>()
            .AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();

        serviceCollection
            .AddHealthChecks()
            .AddDbContextCheck<TContext>();

        return serviceCollection;
    }

    public static IServiceCollection AddRedisCaching(
        this IServiceCollection serviceCollection,
        IConfiguration configuration
        )
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
        .AddOptions<AccessTokenOptions>()
        .BindConfiguration(nameof(AccessTokenOptions))
        .ValidateDataAnnotations()
        .ValidateOnStart();

        var accessTokenOptions = configuration
            .GetSection(nameof(AccessTokenOptions))
            .Get<AccessTokenOptions>()!;

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
            .AddScoped<ISortOrderFactory, SortOrderFactory>()
            .AddImplementationsOf<ISortOrder>(CommonInfrastructureReference.Assembly);

        return serviceCollection;
    }
}
