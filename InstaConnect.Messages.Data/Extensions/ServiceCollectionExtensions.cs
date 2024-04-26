using InstaConnect.Messages.Data;
using InstaConnect.Messages.Data.Abstractions.Repositories;
using InstaConnect.Messages.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string CONNECTION_STRING_KEY = "Server=instaconnect.messages.database;Port=3306;Database={0};Uid={1};Pwd={2};";

        public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<MessageContext>(options =>
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
                .AddScoped<IMessageRepository, MessageRepository>();

            serviceCollection
                .AddHealthChecks()
                .AddDbContextCheck<MessageContext>();

            return serviceCollection;
        }
    }
}
