using InstaConnect.Shared.Application.Models;

namespace InstaConnect.Shared.Application.Abstractions;

public interface ICacheHandler
{
    Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken);
    Task SetAsync(CacheRequest cacheRequest, CancellationToken cancellationToken);
}
