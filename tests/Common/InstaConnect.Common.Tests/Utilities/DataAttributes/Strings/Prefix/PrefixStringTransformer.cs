using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Prefix;

internal class PrefixStringTransformer : IStringTransformer
{
    public string Transform(string? value)
    {
        var result = DataFaker.GetPrefixString(value);

        return result;
    }
}

