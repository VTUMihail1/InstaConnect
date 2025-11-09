using InstaConnect.Common.Tests.DataAttributes.Strings.Base;
using InstaConnect.Common.Tests.Utilities;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.Prefix;

internal class PrefixStringTransformer : IStringTransformer
{
    public string Transform(string? value)
    {
        var result = DataFaker.GetPrefixString(value);

        return result;
    }
}

