using InstaConnect.Messages.Data.Features.Messages.Abstractions;
using InstaConnect.Messages.Data.Features.Messages.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Messages.Data.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IMessageWriteRepository, MessageWriteRepository>()
            .AddScoped<IMessageReadRepository, MessageReadRepository>();

        return serviceCollection;
    }
}
