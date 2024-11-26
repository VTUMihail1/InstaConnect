using InstaConnect.Shared.Application.Abstractions;
using Microsoft.Extensions.Caching.Distributed;

namespace InstaConnect.Shared.Infrastructure.Helpers;
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

    public async Task SetAsync(string key, object obj, CancellationToken cancellationToken)
    {
        var value = _jsonConverter.Serialize(obj) ?? string.Empty;

        await _distributedCache.SetStringAsync(key, value, cancellationToken);
    }

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken)
    {
        var value = await _distributedCache.GetStringAsync(key, cancellationToken) ?? string.Empty;

        var obj = _jsonConverter.Deserialize<T>(value);

        return obj;

    }
}
