using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Common.Infrastructure.Features.Caching.Models;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static partial class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddSignalR(IConfiguration configuration)
		{
			serviceCollection.AddValidatedOptions<RedisOptions>(RedisOptions.SectionName);
			var options = configuration.GetOptions<RedisOptions>(RedisOptions.SectionName);

			serviceCollection.AddSignalR()
				.AddStackExchangeRedis(options.ConnectionString);

			return serviceCollection;
		}
	}
}
