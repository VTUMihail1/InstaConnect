using InstaConnect.Common.Application.Extensions;
using InstaConnect.Common.Extensions;
using InstaConnect.Follows.Application.Features.Follows.Extensions;
using InstaConnect.Users.Application.Features.Users.Extensions;

namespace InstaConnect.Follows.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddUserServices()
            .AddFollowServices();

        serviceCollection
            .AddCQRS(FollowApplicationReference.Assembly)
            .AddMapper(FollowApplicationReference.Assembly)
            .AddValidators(FollowApplicationReference.Assembly);

        return serviceCollection;
    }
}
