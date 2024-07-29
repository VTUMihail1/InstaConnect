using InstaConnect.Identity.Data.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Data.Features.UserClaims.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Data.Features.UserClaims.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserClaimServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IUserClaimWriteRepository, UserClaimWriteRepository>();

        return serviceCollection;
    }
}
