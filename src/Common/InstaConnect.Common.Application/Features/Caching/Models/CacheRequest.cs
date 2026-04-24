namespace InstaConnect.Common.Application.Features.Caching.Models;

public record CacheRequest(
    string Key,
    object? Data,
    DateTimeOffset Expiration);
