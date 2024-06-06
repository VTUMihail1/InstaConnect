using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<PostsContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            var serverVersion = ServerVersion.AutoDetect(connectionString);

            options.UseMySql(connectionString, serverVersion);
        });

        serviceCollection
            .AddScoped<IPostRepository, PostRepository>()
            .AddScoped<IPostLikeRepository, PostLikeRepository>()
            .AddScoped<IPostCommentRepository, PostCommentRepository>()
            .AddScoped<IPostCommentLikeRepository, PostCommentLikeRepository>();

        serviceCollection
            .AddHealthChecks()
            .AddDbContextCheck<PostsContext>();

        return serviceCollection;
    }
}
