using InstaConnect.Follows.Data.Abstractions.Repositories;
using InstaConnect.Follows.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string CONNECTION_STRING_KEY = "Server=instaconnect.follows.database;Port=3306;Database={0};Uid={1};Pwd={2};";

        public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<FollowsContext>(options =>
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
                .AddScoped<IFollowRepository, FollowRepository>();

            serviceCollection
                .AddHealthChecks()
                .AddDbContextCheck<FollowsContext>();

            return serviceCollection;
        }
    }
}
