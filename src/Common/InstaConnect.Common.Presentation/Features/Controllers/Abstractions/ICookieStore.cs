namespace InstaConnect.Common.Presentation.Features.Controllers.Abstractions;

public interface ICookieStore
{
	public void SetHttpOnly(string key, string value, DateTimeOffset expiresAt);
	public void Set(string key, string value, int expireSeconds);
	public string? Get(string key);
	public void Delete(string key);
}
