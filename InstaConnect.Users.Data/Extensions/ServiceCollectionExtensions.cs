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
        private const string CONNECTION_STRING_KEY = "DefaultConnection";

        public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var tokenOptions = configuration.GetSection(nameof(TokenOptions));

            serviceCollection.AddDbContext<UsersContext>(options =>
            {
                var connectionString = configuration.GetConnectionString(CONNECTION_STRING_KEY);
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
