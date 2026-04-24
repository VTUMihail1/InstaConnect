namespace InstaConnect.Common.Presentation.Features.Controllers.Abstractions;

public interface ICookieStore
{
    void SetHttpOnly(string key, string value, DateTimeOffset expiresAt);
    void Set(string key, string value, int expireSeconds);
    string? Get(string key);
    void Delete(string key);
}
