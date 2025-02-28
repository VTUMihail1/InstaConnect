namespace InstaConnect.Common.Application.Abstractions;
public interface ICachable
{
    public string Key { get; }

    public int ExpirationSeconds { get; }
}
