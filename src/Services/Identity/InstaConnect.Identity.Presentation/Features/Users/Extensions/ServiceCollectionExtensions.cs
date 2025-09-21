using InstaConnect.Common.Infrastructure.Models.Options;

using Microsoft.AspNetCore.Authentication.Cookies;

namespace InstaConnect.Identity.Presentation.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        return serviceCollection;
    }
}
