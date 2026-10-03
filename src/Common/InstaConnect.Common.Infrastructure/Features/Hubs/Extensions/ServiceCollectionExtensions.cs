using InstaConnect.Common.Infrastructure.Features.Caches.Models;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Infrastructure.Features.Hubs.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddHubs(IConfiguration configuration)
		{
			serviceCollection.AddValidatedOptions<RedisOptions>(RedisOptions.SectionName);
			var options = configuration.GetOptions<RedisOptions>(RedisOptions.SectionName);

			serviceCollection.AddSignalR()
				.AddStackExchangeRedis(options.ConnectionString);

			return serviceCollection;
		}
	}
}
