using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Follows.Domain.Features.Follows.Extensions;
using InstaConnect.Follows.Domain.Features.Users.Extensions;

namespace InstaConnect.Follows.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddDomain()
        {
            serviceCollection
                .AddUserServices()
                .AddFollowServices();

            serviceCollection
                .AddMapper(FollowsDomainReference.Assembly, CommonDomainReference.Assembly)
                .AddServicesWithMatchingInterfaces(FollowsDomainReference.Assembly);

            return serviceCollection;
        }
    }
}
