namespace InstaConnect.Common.Application.Features.Caches.Models;

public record CacheRequest(
	string Key,
	object? Data,
	DateTimeOffset Expiration);
