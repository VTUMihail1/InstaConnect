using System.Reflection;
using CloudinaryDotNet;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Data.Helpers;
using InstaConnect.Shared.Data.Models.Options;
using InstaConnect.Shared.Infrastructure.Models.Options;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace InstaConnect.Shared.Data.Extensions;
public static class ServiceCollectionExtensions
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
        serviceCollection
            .AddOptions<DatabaseOptions>()
            .BindConfiguration(nameof(DatabaseOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var databaseOptions = configuration
                    .GetSection(nameof(DatabaseOptions))
                    .Get<DatabaseOptions>()!;

        serviceCollection.AddDbContext<TContext>(options =>
        {
            options.AddInterceptors(new AuditableEntityInterceptor());

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

    public static IServiceCollection AddCaching(
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
            .AddScoped<ICacheHandler, CacheHandler>();

        serviceCollection.AddStackExchangeRedisCache(redisOptions =>
            redisOptions.Configuration = cacheOptions.ConnectionString);

        serviceCollection
            .AddHealthChecks()
            .AddRedis(cacheOptions.ConnectionString);

        return serviceCollection;
    }

    public static IServiceCollection AddMessageBroker(
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
        serviceCollection
        .AddOptions<AccessTokenOptions>()
        .BindConfiguration(nameof(AccessTokenOptions))
        .ValidateDataAnnotations()
        .ValidateOnStart();

        var tokenOptions = configuration
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
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(tokenOptions.SecurityKeyByteArray),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        return serviceCollection;
    }

    public static IServiceCollection AddImageHandler(this IServiceCollection serviceCollection, IConfiguration configuration)
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
}
