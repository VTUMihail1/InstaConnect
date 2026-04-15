using InstaConnect.Common.Infrastructure.Extensions;

using Microsoft.Extensions.Caching.Distributed;

namespace InstaConnect.Common.Infrastructure.Extensions;

internal static class DistributedCacheExtensions
{
    extension(IDistributedCache distributedCache)
    {
        public async Task SetStringAsync(string key, string value, DateTimeOffset expiration, CancellationToken cancellationToken)
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
}
