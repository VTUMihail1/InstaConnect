using InstaConnect.Common.Application.Features.Caching.Abstractions;
using InstaConnect.Common.Application.Features.Caching.Models;
using InstaConnect.Common.Infrastructure.Features.Caching.Abstractions;

using Microsoft.Extensions.Caching.Distributed;

namespace InstaConnect.Common.Infrastructure.Features.Caching.Helpers;


internal class CacheHandler : ICacheHandler
{
	private readonly IJsonConverter _jsonConverter;
	private readonly IDistributedCache _distributedCache;

	public CacheHandler(
		IJsonConverter jsonConverter,
		IDistributedCache distributedCache)
	{
		_jsonConverter = jsonConverter;
		_distributedCache = distributedCache;
	}

	public async Task SetAsync(CacheRequest cacheRequest, CancellationToken cancellationToken)
	{
		var value = _jsonConverter.Serialize(cacheRequest.Data) ?? string.Empty;
		await _distributedCache.SetStringAsync(
			cacheRequest.Key,
			value,
			new DistributedCacheEntryOptions
			{
				AbsoluteExpiration = cacheRequest.Expiration,
			},
			cancellationToken);
	}

	public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken)
	{
		var value = await _distributedCache.GetStringAsync(key, cancellationToken) ?? string.Empty;

		var obj = _jsonConverter.Deserialize<T>(value);

		return obj;

	}
}

