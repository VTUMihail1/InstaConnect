using InstaConnect.Posts.Write.Data.Abstract;
using InstaConnect.Posts.Write.Data.Helpers;
using InstaConnect.Posts.Write.Data.Repositories;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Write.Data.Extensions;

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
