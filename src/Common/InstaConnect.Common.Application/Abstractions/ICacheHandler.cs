using InstaConnect.Common.Application.Models;

namespace InstaConnect.Common.Application.Abstractions;

public interface ICacheHandler
{
    Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken);
    Task SetAsync(CacheRequest cacheRequest, CancellationToken cancellationToken);
}
