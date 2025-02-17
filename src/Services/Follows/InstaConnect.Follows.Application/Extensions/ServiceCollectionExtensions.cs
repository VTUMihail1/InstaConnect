using InstaConnect.Follows.Application.Features.Follows.Extensions;
using InstaConnect.Shared.Application.Extensions;
using InstaConnect.Shared.Common.Extensions;

namespace InstaConnect.Follows.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddFollowServices();

        serviceCollection
            .AddMediatR(ApplicationReference.Assembly)
            .AddMapper(ApplicationReference.Assembly)
            .AddValidators(ApplicationReference.Assembly);

        return serviceCollection;
    }
}
