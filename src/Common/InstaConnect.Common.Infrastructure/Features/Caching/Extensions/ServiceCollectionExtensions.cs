using InstaConnect.Common.Application.Features.Caching.Abstractions;
using InstaConnect.Common.Application.Features.Caching.Helpers;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Common.Infrastructure.Features.Caching.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Caching.Helpers;
using InstaConnect.Common.Infrastructure.Features.Caching.Models;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static partial class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddRedis(IConfiguration configuration)
		{
			serviceCollection.AddValidatedOptions<RedisOptions>(RedisOptions.SectionName);
			var options = configuration.GetOptions<RedisOptions>(RedisOptions.SectionName);

			serviceCollection.AddScoped<IJsonConverter, JsonConverter>()
							 .AddScoped<ICacheHandler, CacheHandler>()
							 .AddScoped<ICacheRequestFactory, CacheRequestFactory>();

			serviceCollection.AddStackExchangeRedisCache(redisOptions =>
				redisOptions.Configuration = options.ConnectionString);

			serviceCollection.AddHealthChecks()
							 .AddRedis(options.ConnectionString);

			return serviceCollection;
		}
	}
}
