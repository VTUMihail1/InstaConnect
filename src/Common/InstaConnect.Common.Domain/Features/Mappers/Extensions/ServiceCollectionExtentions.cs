using System.Reflection;

using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Helpers;

using Mapster;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Domain.Features.Mappers.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddMapper(params Assembly[] assemblies)
		{
			serviceCollection.AddMapster();

			var config = TypeAdapterConfig.GlobalSettings;
			config.Scan(assemblies);
			serviceCollection.AddSingleton(config);

			serviceCollection.AddScoped<IApplicationMapper, ApplicationMapper>();

			return serviceCollection;
		}
	}
}
