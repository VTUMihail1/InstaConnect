using InstaConnect.Common.Infrastructure.Models.Options;

using Microsoft.AspNetCore.Authentication.Cookies;

namespace InstaConnect.Identity.Presentation.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var accessTokenOptions = configuration
            .GetSection(nameof(AccessTokenOptions))
            .Get<AccessTokenOptions>()!;

        serviceCollection
            .Configure<CookieAuthenticationOptions>(options => options.ExpireTimeSpan = TimeSpan.FromSeconds(accessTokenOptions.LifetimeSeconds));

        return serviceCollection;
    }
}
