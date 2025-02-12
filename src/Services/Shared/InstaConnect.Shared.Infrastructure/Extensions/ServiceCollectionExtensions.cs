using System.Reflection;
using CloudinaryDotNet;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Helpers;
using InstaConnect.Shared.Infrastructure.Abstractions;
using InstaConnect.Shared.Infrastructure.Extensions;
using InstaConnect.Shared.Infrastructure.Helpers;
using InstaConnect.Shared.Infrastructure.Interceptors;
using InstaConnect.Shared.Infrastructure.Models.Options;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WebMotions.Fake.Authentication.JwtBearer;

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

    public static IServiceCollection AddDatabaseContext<TContext>(
        this IServiceCollection serviceCollection,
        IConfiguration configuration,
        Action<DbContextOptionsBuilder>? optionsAction = null)
    where TContext : DbContext
    {
        serviceCollection.AddScoped<AuditableEntityInterceptor>();

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
            var auditableEntityInterceptor = sp.GetRequiredService<AuditableEntityInterceptor>();

            options.AddInterceptors(auditableEntityInterceptor);

            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            options.UseSqlServer(
                    databaseOptions.ConnectionString,
                    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());

            optionsAction?.Invoke(options);
        });

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

    public static IServiceCollection AddTestDbContext<TContext>(this IServiceCollection serviceCollection, Action<DbContextOptionsBuilder>? optionsAction = null)
      where TContext : DbContext
    {
        var efCoreDescriptor = serviceCollection.SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<TContext>));

        if (efCoreDescriptor != null)
        {
            serviceCollection.Remove(efCoreDescriptor);
        }

        serviceCollection.AddDbContext<TContext>(options => optionsAction?.Invoke(options));

        return serviceCollection;
    }

    public static IServiceCollection AddTestJwtAuth(this IServiceCollection serviceCollection)
    {
        serviceCollection
                .AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = FakeJwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = FakeJwtBearerDefaults.AuthenticationScheme;
                })
                .AddFakeJwtBearer(opt => opt.BearerValueType = FakeJwtBearerBearerValueType.Jwt);

        return serviceCollection;
    }

    public static IServiceCollection AddTestRedisCache(this IServiceCollection serviceCollection, Action<RedisCacheOptions>? optionsAction = null!)
    {
        var descriptor = serviceCollection.SingleOrDefault(s => s.ServiceType == typeof(IDistributedCache));

        if (descriptor != null)
        {
            serviceCollection.Remove(descriptor);
        }

        serviceCollection.AddStackExchangeRedisCache(options => optionsAction?.Invoke(options));

        return serviceCollection;
    }
}
