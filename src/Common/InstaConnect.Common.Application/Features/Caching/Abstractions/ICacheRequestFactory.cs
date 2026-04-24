using InstaConnect.Common.Application.Features.Caching.Models;

namespace InstaConnect.Common.Application.Features.Caching.Abstractions;

public interface ICacheRequestFactory
{
    CacheRequest Get(string key, int expirationSeconds, object? data);
}
