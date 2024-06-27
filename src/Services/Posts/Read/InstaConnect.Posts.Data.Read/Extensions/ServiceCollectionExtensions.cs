﻿using InstaConnect.Messages.Data.Read.Abstractions;
using InstaConnect.Messages.Data.Read.Repositories;
using InstaConnect.Posts.Data.Read.Abstract;
using InstaConnect.Posts.Data.Read.Helpers;
using InstaConnect.Posts.Data.Read.Repositories;
using InstaConnect.Shared.Data;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data.Extensions;
using InstaConnect.Shared.Data.Models.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Data.Read.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddDatabaseOptions()
            .AddDatabaseContext<PostsContext>(options =>
            {
                var databaseOptions = configuration
                    .GetSection(nameof(DatabaseOptions))
                    .Get<DatabaseOptions>()!;
           
                options.UseSqlServer(
                    databaseOptions.ConnectionString,
                    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
            });

        serviceCollection
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IPostRepository, PostRepository>()
            .AddScoped<IPostLikeRepository, PostLikeRepository>()
            .AddScoped<IPostCommentRepository, PostCommentRepository>()
            .AddScoped<IPostCommentLikeRepository, PostCommentLikeRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
            .AddUnitOfWork<PostsContext>();

        return serviceCollection;
    }
}
