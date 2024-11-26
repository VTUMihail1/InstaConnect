using InstaConnect.Posts.Domain.Features.Users.Abstract;
using InstaConnect.Posts.Infrastructure.Features.Users.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IUserWriteRepository, UserWriteRepository>();

        return serviceCollection;
    }
}
