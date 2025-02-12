using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserClaimServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddTransient<IUserClaimWriteRepository, UserClaimWriteRepository>();

        return serviceCollection;
    }
}
