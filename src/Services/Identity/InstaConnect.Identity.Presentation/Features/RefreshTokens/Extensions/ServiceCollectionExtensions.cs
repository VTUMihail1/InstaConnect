using InstaConnect.Common.Infrastructure.Models.Options;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;

namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddRefreshTokenServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        return serviceCollection;
    }
}
