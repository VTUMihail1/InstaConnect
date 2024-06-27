﻿using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Azure.Messaging;
using InstaConnect.Shared.Data.Extensions;
using InstaConnect.Follows.Data.Read;
using InstaConnect.Follows.Data.Read.Helpers;
using InstaConnect.Follows.Data.Read.Repositories;
using InstaConnect.Follows.Data.Read.Abstractions;
using InstaConnect.Shared.Data.Models.Options;

namespace InstaConnect.Follows.Data.Read.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<FollowsContext>(options => options.UseSqlServer(""));

        serviceCollection
            .AddDatabaseOptions()
            .AddDatabaseContext<FollowsContext>(options =>
            {
                var databaseOptions = configuration
                    .GetSection(nameof(DatabaseOptions))
                    .Get<DatabaseOptions>()!;

                options.UseSqlServer(
                    databaseOptions.ConnectionString,
                    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
            });

        serviceCollection
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IFollowRepository, FollowRepository>()
            .AddUnitOfWork<FollowsContext>();

        return serviceCollection;
    }
}
