using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string CONNECTION_STRING_KEY = "Server=instaconnect.posts.database;Port=3306;Database={0};Uid={1};Pwd={2};";

        public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<PostsContext>(options =>
            {
                var connectionString = configuration.GetConnectionString(
                    string.Format(CONNECTION_STRING_KEY,
                    Environment.GetEnvironmentVariable("MYSQL_DB"),
                    Environment.GetEnvironmentVariable("MYSQL_USER"),
                    Environment.GetEnvironmentVariable("MYSQL_ROOT_PASSWORD")));
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
}
