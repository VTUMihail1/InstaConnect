using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Common.Tests.Features.Utilities;

namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.TooLong;

internal class TooLongStringTransformer : IStringTransformer
{
    private readonly int _maxLength;

    public TooLongStringTransformer(int maxLength)
    {
        _maxLength = maxLength;
    }

    public string Transform(string? value)
    {
        var result = DataFaker.GetString(_maxLength.Increment());

        return result;
    }
}

