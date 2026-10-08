using InstaConnect.Common.Application.Features.Caches.Models;

namespace InstaConnect.Common.Application.Features.Caches.Abstractions;

public interface ICacheRequestFactory
{
	public CacheRequest Get(string key, int expirationSeconds, object? data);
}
