namespace InstaConnect.Shared.Business.Abstractions;
public interface ICachable
{
    public string Key { get; }

    public DateTimeOffset Expiration { get; }
}
