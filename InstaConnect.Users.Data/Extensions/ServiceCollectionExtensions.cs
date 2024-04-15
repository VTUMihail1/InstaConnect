using InstaConnect.Shared.Repositories.Abstract;
using InstaConnect.Shared.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaConnect.Users.Data.Abstraction.Repositories;
using InstaConnect.Users.Data.Repositories;
using InstaConnect.Users.Data.Factories;
using InstaConnect.Users.Data.Abstraction.Factories;
using InstaConnect.Users.Data.Abstraction.Helpers;
using InstaConnect.Users.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using InstaConnect.Users.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Users.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string CONNECTION_STRING_KEY = "DefaultConnection";

        public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
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
