using System.Text;

using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Common.Infrastructure.Helpers;

internal class Encoder : IEncoder
{
    public byte[] GetBytesUTF8(string key)
    {
        var bytes = Encoding.UTF8.GetBytes(key);

        return bytes;
    }
}
