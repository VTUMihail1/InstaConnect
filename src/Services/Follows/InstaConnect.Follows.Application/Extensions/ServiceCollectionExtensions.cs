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
                .AddCQRS(FollowApplicationReference.Assembly)
                .AddMapper(FollowApplicationReference.Assembly, CommonApplicationReference.Assembly)
                .AddValidators(FollowApplicationReference.Assembly);

            return serviceCollection;
        }
    }
}
