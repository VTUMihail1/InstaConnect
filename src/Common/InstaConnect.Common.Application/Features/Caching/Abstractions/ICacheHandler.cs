using InstaConnect.Common.Application.Features.Caching.Models;

namespace InstaConnect.Common.Application.Features.Caching.Abstractions;

public interface ICacheHandler
{
    Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken);
    Task SetAsync(CacheRequest cacheRequest, CancellationToken cancellationToken);
}
