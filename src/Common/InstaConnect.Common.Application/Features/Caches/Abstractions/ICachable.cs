namespace InstaConnect.Common.Application.Features.Caches.Abstractions;

public interface ICachable
{
	public string Key { get; }

	public int ExpirationSeconds { get; }
}
