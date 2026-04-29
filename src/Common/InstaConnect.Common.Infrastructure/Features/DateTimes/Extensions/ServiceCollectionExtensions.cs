using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Infrastructure.Features.DateTimes.Helpers;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static partial class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddDateTimeProvider()
		{
			serviceCollection.AddScoped<IDateTimeProvider, DateTimeProvider>();

			return serviceCollection;
		}
	}
}
