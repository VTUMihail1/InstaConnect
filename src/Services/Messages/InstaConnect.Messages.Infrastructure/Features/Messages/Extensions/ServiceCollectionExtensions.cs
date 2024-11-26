using InstaConnect.Messages.Domain.Features.Users.Abstract;
using InstaConnect.Messages.Infrastructure.Features.Users.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Infrastructure.Features.Messages.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddMessageServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IUserWriteRepository, UserWriteRepository>();

        return serviceCollection;
    }
}
