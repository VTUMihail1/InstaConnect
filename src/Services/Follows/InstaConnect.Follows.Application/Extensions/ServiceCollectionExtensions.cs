using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Follows.Application.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddApplication()
        {
            serviceCollection
                .AddUserServices()
                .AddFollowServices();

            serviceCollection
                .AddCQRS(FollowsApplicationReference.Assembly)
                .AddMapper(FollowsApplicationReference.Assembly, CommonApplicationReference.Assembly)
                .AddValidators(FollowsApplicationReference.Assembly);

            return serviceCollection;
        }
    }
}
