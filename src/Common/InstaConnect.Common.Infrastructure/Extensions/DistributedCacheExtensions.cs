using InstaConnect.Common.Infrastructure.Extensions;

using Microsoft.Extensions.Caching.Distributed;

namespace InstaConnect.Common.Infrastructure.Extensions;

internal static class DistributedCacheExtensions
{
    public static async Task SetStringAsync(
        this IDistributedCache distributedCache,
        string key,
        string value,
        DateTimeOffset expiration,
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

