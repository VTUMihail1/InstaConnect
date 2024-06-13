using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data;
using InstaConnect.Users.Business.Abstractions;
using InstaConnect.Users.Business.Helpers;
using InstaConnect.Users.Data.Abstraction.Factories;
using InstaConnect.Users.Data.Abstraction.Helpers;
using InstaConnect.Users.Data.Abstraction.Repositories;
using InstaConnect.Users.Data.Factories;
using InstaConnect.Users.Data.Helpers;
using InstaConnect.Users.Data.Models.Entities;
using InstaConnect.Users.Data.Models.Options;
using InstaConnect.Users.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TokenOptions = InstaConnect.Users.Data.Models.Options.TokenOptions;

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
            .AddOptions<TokenOptions>()
            .BindConfiguration(nameof(TokenOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        serviceCollection
            .AddDbContext<UsersContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        serviceCollection
            .AddScoped<IUnitOfWork, UnitOfWork>(sp => new UnitOfWork(sp.GetRequiredService<UsersContext>()))
            .AddScoped<ITokenRepository, TokenRepository>()
            .AddScoped<ITokenFactory, TokenFactory>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<ITokenGenerator, TokenGenerator>()
            .AddScoped<IUserClaimRepository, UserClaimRepository>()
            .AddScoped<IPasswordHasher, PasswordHasher>()
            .AddScoped<IDatabaseSeeder, DatabaseSeeder>();

        serviceCollection
            .AddHealthChecks()
            .AddDbContextCheck<UsersContext>();


        return serviceCollection;
    }
}
