using InstaConnect.Shared.Data.Models.Options;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace InstaConnect.Identity.Web.Features.Accounts.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddAccountServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var tokenOptions = configuration
            .GetSection(nameof(TokenOptions))
            .Get<TokenOptions>()!;

        serviceCollection
            .Configure<CookieAuthenticationOptions>(options => options.ExpireTimeSpan = TimeSpan.FromSeconds(tokenOptions.AccountTokenLifetimeSeconds));

        return serviceCollection;
    }
}
