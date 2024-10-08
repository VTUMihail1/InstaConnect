﻿using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Data.Helpers;
using InstaConnect.Shared.Data.Models.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
}
