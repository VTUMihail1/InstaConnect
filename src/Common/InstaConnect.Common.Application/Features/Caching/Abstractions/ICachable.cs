namespace InstaConnect.Common.Application.Features.Caching.Abstractions;

public interface ICachable
{
	public string Key { get; }

	public int ExpirationSeconds { get; }
}
