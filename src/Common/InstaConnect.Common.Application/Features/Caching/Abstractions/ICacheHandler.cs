using InstaConnect.Common.Application.Features.Caching.Models;

namespace InstaConnect.Common.Application.Features.Caching.Abstractions;

public interface ICacheHandler
{
	public Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken);

	public Task SetAsync(CacheRequest cacheRequest, CancellationToken cancellationToken);
}
