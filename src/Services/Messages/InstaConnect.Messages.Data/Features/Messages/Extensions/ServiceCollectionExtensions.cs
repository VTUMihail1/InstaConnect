using InstaConnect.Messages.Data.Features.Users.Abstract;
using InstaConnect.Messages.Data.Features.Users.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Data.Features.Messages.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddMessageServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IUserWriteRepository, UserWriteRepository>()
            .AddScoped<IUserReadRepository, UserReadRepository>();

        return serviceCollection;
    }
}
