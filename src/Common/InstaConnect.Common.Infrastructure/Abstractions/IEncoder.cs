namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface IEncoder
{
    byte[] GetBytesUTF8(string key);
}
