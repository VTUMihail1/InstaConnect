using System.Text;

using InstaConnect.Common.Infrastructure.Features.Tokens.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Tokens.Helpers;

internal class Encoder : IEncoder
{
    public byte[] GetBytesUTF8(string key)
    {
        var bytes = Encoding.UTF8.GetBytes(key);

        return bytes;
    }
}
