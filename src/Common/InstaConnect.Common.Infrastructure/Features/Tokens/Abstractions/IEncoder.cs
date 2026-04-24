namespace InstaConnect.Common.Infrastructure.Features.Tokens.Abstractions;

public interface IEncoder
{
    byte[] GetBytesUTF8(string key);
}
