using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data.Extensions;
using InstaConnect.Users.Data.Abstraction;
using InstaConnect.Users.Data.Factories;
using InstaConnect.Users.Data.Helpers;
using InstaConnect.Users.Data.Models.Options;
using InstaConnect.Users.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Users.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddOptions<AdminOptions>()
            .BindConfiguration(nameof(AdminOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        serviceCollection
            .AddScoped<ITokenRepository, TokenRepository>()
            .AddScoped<ITokenFactory, TokenFactory>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<ITokenGenerator, TokenGenerator>()
            .AddScoped<IUserClaimRepository, UserClaimRepository>()
            .AddScoped<IPasswordHasher, PasswordHasher>()
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
            .AddDatabaseContext<UsersContext>(configuration)
            .AddUnitOfWork<UsersContext>();
        ;


        return serviceCollection;
    }
}
