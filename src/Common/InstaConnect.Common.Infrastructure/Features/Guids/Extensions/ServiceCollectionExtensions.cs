using InstaConnect.Common.Domain.Features.Guids.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Guids.Helpers;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static partial class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddGuidProvider()
		{
			serviceCollection.AddScoped<IGuidProvider, GuidProvider>();

			return serviceCollection;
		}
	}
}
