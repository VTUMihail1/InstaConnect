using InstaConnect.Posts.Data.Write.Abstract;
using InstaConnect.Posts.Data.Write.Helpers;
using InstaConnect.Posts.Data.Write.Repositories;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Data.Write.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddDatabaseOptions()
            .AddDbContext<PostsContext>(options => options.UseSqlServer(""));

        serviceCollection
            .AddScoped<IPostRepository, PostRepository>()
            .AddScoped<IPostLikeRepository, PostLikeRepository>()
            .AddScoped<IPostCommentRepository, PostCommentRepository>()
            .AddScoped<IPostCommentLikeRepository, PostCommentLikeRepository>()
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
            .AddUnitOfWork<PostsContext>();

        return serviceCollection;
    }
}
