using InstaConnect.Shared.Application.Models;

namespace InstaConnect.Shared.Application.Helpers;

public class CacheRequestFactory : ICacheRequestFactory
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public CacheRequestFactory(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public CacheRequest Get(string key, int expirationSeconds, object? data)
    {
        var absoluteExpiration = _dateTimeProvider.GetCurrentUtc(expirationSeconds);
        var cacheRequest = new CacheRequest(key, data, absoluteExpiration);

        return cacheRequest;
    }
}
