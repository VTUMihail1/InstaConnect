using InstaConnect.Common.Application.Models;

namespace InstaConnect.Common.Application.Abstractions;

public interface ICacheRequestFactory
{
    CacheRequest Get(string key, int expirationSeconds, object? data);
}
