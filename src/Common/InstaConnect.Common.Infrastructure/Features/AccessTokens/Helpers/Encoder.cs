using System.Text;

using InstaConnect.Common.Infrastructure.Features.AccessTokens.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.AccessTokens.Helpers;

internal class Encoder : IEncoder
{
	public byte[] GetBytesUTF8(string key)
	{
		var bytes = Encoding.UTF8.GetBytes(key);

		return bytes;
	}
}
