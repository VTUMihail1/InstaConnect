using InstaConnect.Users.Data.Abstraction.Factories;
using InstaConnect.Users.Data.Abstraction.Helpers;
using InstaConnect.Users.Data.Abstraction.Repositories;
using InstaConnect.Users.Data.Factories;
using InstaConnect.Users.Data.Helpers;
using InstaConnect.Users.Data.Models.Entities;
using InstaConnect.Users.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Users.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string CONNECTION_STRING_KEY = "Server=instaconnect.users.database;Port=3306;Database={0};Uid={1};Pwd={2};";

        public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var tokenOptions = configuration.GetSection(nameof(TokenOptions));

            serviceCollection.AddDbContext<UsersContext>(options =>
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
                .AddScoped<ITokenRepository, TokenRepository>()
                .AddScoped<ITokenFactory, TokenFactory>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ITokenGenerator, TokenGenerator>()
                .AddScoped<IAccountManager, AccountManager>()
                .AddScoped<IDatabaseSeeder, DatabaseSeeder>();

            serviceCollection
                .AddHealthChecks()
                .AddDbContextCheck<UsersContext>();

            serviceCollection
                .AddIdentity<User, Role>()
                .AddEntityFrameworkStores<UsersContext>()
                .AddDefaultTokenProviders();


            return serviceCollection;
        }
    }
}
