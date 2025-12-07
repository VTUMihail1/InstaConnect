using InstaConnect.Common.Domain.Extensions;

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
            .AddMapper(FollowApplicationReference.Assembly, CommonApplicationReference.Assembly)
            .AddValidators(FollowApplicationReference.Assembly);

        return serviceCollection;
    }
}
