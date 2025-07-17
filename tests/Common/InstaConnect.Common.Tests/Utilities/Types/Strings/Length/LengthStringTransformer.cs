using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;

namespace InstaConnect.Common.Tests.Utilities.Types.Strings.Length;

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

