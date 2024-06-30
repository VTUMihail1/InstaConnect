namespace InstaConnect.Shared.Business.Abstractions;
public interface ICachable
{
    public string Key { get; set; }

    public DateTimeOffset Expiration { get; set; }
}
