using InstaConnect.Shared.Infrastructure.Models.Options;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddForgotPasswordTokenServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
