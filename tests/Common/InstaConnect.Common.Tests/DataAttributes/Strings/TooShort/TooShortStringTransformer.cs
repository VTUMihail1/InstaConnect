using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Tests.DataAttributes.Strings.Base;
using InstaConnect.Common.Tests.Utilities;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.TooShort;

internal class TooShortStringTransformer : IStringTransformer
{
    private readonly int _minLength;

    public TooShortStringTransformer(int minLength)
    {
        _minLength = minLength;
    }

    public string Transform(string? value)
    {
        var result = DataFaker.GetString(_minLength.Decrement());

        return result;
    }
}

