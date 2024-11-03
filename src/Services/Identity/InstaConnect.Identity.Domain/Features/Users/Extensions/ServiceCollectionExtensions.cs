using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Identity.Data.Features.Users.Helpers;
using InstaConnect.Identity.Data.Features.Users.Models.Options;
using InstaConnect.Identity.Data.Features.Users.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Data.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddOptions<AdminOptions>()
            .BindConfiguration(nameof(AdminOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        serviceCollection
            .AddTransient<IUserWriteRepository, UserWriteRepository>()
            .AddTransient<IUserReadRepository, UserReadRepository>()
            .AddScoped<IPasswordHasher, PasswordHasher>();

        return serviceCollection;
    }
}
