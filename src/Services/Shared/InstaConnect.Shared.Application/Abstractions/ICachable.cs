namespace InstaConnect.Shared.Application.Abstractions;
public interface ICachable
{
    public string Key { get; }

    public DateTimeOffset Expiration { get; }
}
