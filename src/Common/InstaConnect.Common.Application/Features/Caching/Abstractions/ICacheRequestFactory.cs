using InstaConnect.Common.Application.Features.Caching.Models;

namespace InstaConnect.Common.Application.Features.Caching.Abstractions;

public interface ICacheRequestFactory
{
	public CacheRequest Get(string key, int expirationSeconds, object? data);
}
