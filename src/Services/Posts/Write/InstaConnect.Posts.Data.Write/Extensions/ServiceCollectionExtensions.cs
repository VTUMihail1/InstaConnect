using InstaConnect.Posts.Data.Abstract;
using InstaConnect.Posts.Data.Helpers;
using InstaConnect.Posts.Data.Repositories;
using InstaConnect.Shared.Data;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddScoped<IPostRepository, PostRepository>()
            .AddScoped<IPostLikeRepository, PostLikeRepository>()
            .AddScoped<IPostCommentRepository, PostCommentRepository>()
            .AddScoped<IPostCommentLikeRepository, PostCommentLikeRepository>()
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
            .AddDatabaseContext<PostsContext>(configuration)
            .AddUnitOfWork<PostsContext>();

        return serviceCollection;
    }
}
