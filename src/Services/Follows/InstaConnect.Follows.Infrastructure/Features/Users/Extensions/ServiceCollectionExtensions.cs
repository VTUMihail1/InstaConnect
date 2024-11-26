using InstaConnect.Follows.Domain.Features.Users.Abstractions;
using InstaConnect.Follows.Infrastructure.Features.Users.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Extensions;
internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IUserWriteRepository, UserWriteRepository>();

        return serviceCollection;
    }
}
