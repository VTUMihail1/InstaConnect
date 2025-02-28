namespace InstaConnect.Common.Application.Models;

public record CacheRequest(
    string Key,
    object? Data,
    DateTimeOffset Expiration);
