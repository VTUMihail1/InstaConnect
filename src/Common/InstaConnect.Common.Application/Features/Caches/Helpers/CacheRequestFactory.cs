using InstaConnect.Common.Application.Features.Caches.Abstractions;
using InstaConnect.Common.Application.Features.Caches.Models;
using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;

namespace InstaConnect.Common.Application.Features.Caches.Helpers;

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
