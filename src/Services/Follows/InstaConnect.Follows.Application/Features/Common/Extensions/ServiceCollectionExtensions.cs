using InstaConnect.Common.Application.Features.Common.Extensions;
using InstaConnect.Common.Application.Features.Messaging.Extensions;
using InstaConnect.Common.Domain.Features.Mappers.Extensions;

namespace InstaConnect.Follows.Application.Features.Common.Extensions;

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
