using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Models;
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

    public async Task SetAsync(CacheRequest cacheRequest, CancellationToken cancellationToken)
    {
        var value = _jsonConverter.Serialize(cacheRequest.Data) ?? string.Empty;
        await _distributedCache.SetStringAsync(
            cacheRequest.Key,
            value,
            cacheRequest.Expiration,
            cancellationToken);
    }

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken)
    {
        var value = await _distributedCache.GetStringAsync(key, cancellationToken) ?? string.Empty;

        var obj = _jsonConverter.Deserialize<T>(value);

        return obj;

    }
}

internal static class DistributedCacheExtensions
{
    public static async Task SetStringAsync(
        this IDistributedCache distributedCache,
        string key,
        string value,
        DateTime expiration,
        CancellationToken cancellationToken)
    {
        await distributedCache.SetStringAsync(
            key,
            value,
            new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = expiration,
            },
            cancellationToken);
    }
}

