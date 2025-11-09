using InstaConnect.Common.Tests.DataAttributes.Strings.Base;
using InstaConnect.Common.Tests.Utilities;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.Length;

internal class LengthStringTransformer : IStringTransformer
{
    private readonly int _length;

    public LengthStringTransformer(int length)
    {
        _length = length;
    }

    public string Transform(string? value)
    {
        var result = DataFaker.GetString(_length);

        return result;
    }
}

