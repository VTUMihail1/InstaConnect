using InstaConnect.Common.Application.Models;
using InstaConnect.Common.Domain.Abstractions;

namespace InstaConnect.Common.Application.Helpers;

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
