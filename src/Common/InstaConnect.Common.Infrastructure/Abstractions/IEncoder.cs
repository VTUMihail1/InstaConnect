namespace InstaConnect.Shared.Infrastructure.Abstractions;

public interface IEncoder
{
    byte[] GetBytesUTF8(string key);
}
