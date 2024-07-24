using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Posts.Read.Data.Helpers;
using InstaConnect.Posts.Read.Data.Repositories;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data.Extensions;
using InstaConnect.Shared.Data.Models.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Read.Data.Extensions;

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
            .AddScoped<IUserReadRepository, UserReadRepository>()
            .AddScoped<IPostReadRepository, PostReadRepository>()
            .AddScoped<IPostLikeReadRepository, PostLikeReadRepository>()
            .AddScoped<IPostCommentReadRepository, PostCommentReadRepository>()
            .AddScoped<IPostCommentLikeReadRepository, PostCommentLikeReadRepository>()
            .AddScoped<IUserReadRepository, UserReadRepository>()
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
            .AddCaching(configuration)
            .AddUnitOfWork<PostsContext>();

        return serviceCollection;
    }
}
