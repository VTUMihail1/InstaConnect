using InstaConnect.Shared.Data.Models.Options;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace InstaConnect.Identity.Web.Features.Accounts.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddAccountServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var accessTokenOptions = configuration
            .GetSection(nameof(AccessTokenOptions))
            .Get<AccessTokenOptions>()!;

        serviceCollection
            .Configure<CookieAuthenticationOptions>(options => options.ExpireTimeSpan = TimeSpan.FromSeconds(accessTokenOptions.LifetimeSeconds));

        return serviceCollection;
    }
}
