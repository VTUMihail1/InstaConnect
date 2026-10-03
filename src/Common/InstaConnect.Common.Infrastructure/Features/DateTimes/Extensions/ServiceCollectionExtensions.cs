using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Infrastructure.Features.DateTimes.Helpers;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Infrastructure.Features.DateTimes.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddDateTimes()
		{
			serviceCollection.AddSingleton<IDateTimeProvider, DateTimeProvider>();

			return serviceCollection;
		}
	}
}
