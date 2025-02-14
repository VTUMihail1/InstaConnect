using InstaConnect.Messages.Domain.Features.Users.Abstract;
using InstaConnect.Messages.Infrastructure.Features.Users.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Infrastructure.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
