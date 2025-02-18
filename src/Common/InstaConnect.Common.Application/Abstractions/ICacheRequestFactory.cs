using InstaConnect.Shared.Application.Models;

namespace InstaConnect.Shared.Application.Abstractions;

public interface ICacheRequestFactory
{
    CacheRequest Get(string key, int expirationSeconds, object? data);
}
