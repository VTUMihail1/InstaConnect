using InstaConnect.Shared.Infrastructure.Models.Options;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddEmailConfirmationTokenServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
