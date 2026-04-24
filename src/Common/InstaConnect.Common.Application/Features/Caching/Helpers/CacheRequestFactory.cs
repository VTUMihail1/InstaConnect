using InstaConnect.Common.Application.Features.Caching.Abstractions;
using InstaConnect.Common.Application.Features.Caching.Models;
using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;

namespace InstaConnect.Common.Application.Features.Caching.Helpers;

public class CacheRequestFactory : ICacheRequestFactory
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public CacheRequestFactory(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public CacheRequest Get(string key, int expirationSeconds, object? data)
    {
        var absoluteExpiration = _dateTimeProvider.GetOffsetUtcNow(expirationSeconds);
        var cacheRequest = new CacheRequest(key, data, absoluteExpiration);

        return cacheRequest;
    }
}
