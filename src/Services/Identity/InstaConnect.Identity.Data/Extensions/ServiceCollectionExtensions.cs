using InstaConnect.Identity.Data;
using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Identity.Data.Factories;
using InstaConnect.Identity.Data.Helpers;
using InstaConnect.Identity.Data.Models.Options;
using InstaConnect.Identity.Data.Repositories;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data.Extensions;
using InstaConnect.Shared.Data.Models.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Data.Extensions;

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
            .AddDatabaseOptions()
            .AddDatabaseContext<IdentityContext>(options =>
            {
                var databaseOptions = configuration
                    .GetSection(nameof(DatabaseOptions))
                    .Get<DatabaseOptions>()!;

                options.UseSqlServer(
                    databaseOptions.ConnectionString,
                    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
            });

        serviceCollection
            .AddScoped<ITokenRepository, TokenRepository>()
            .AddScoped<ITokenFactory, TokenFactory>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<ITokenGenerator, TokenGenerator>()
            .AddScoped<IUserClaimRepository, UserClaimRepository>()
            .AddScoped<IPasswordHasher, PasswordHasher>()
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
            .AddUnitOfWork<IdentityContext>();

        return serviceCollection;
    }
}
