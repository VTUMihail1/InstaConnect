namespace InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;

public interface IEncoder
{
	public byte[] GetBytesUTF8(string key);
}
