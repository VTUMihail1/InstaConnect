using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;

namespace InstaConnect.Common.Tests.Utilities.Types.Strings.Prefix;

internal class PrefixStringTransformer : IStringTransformer
{
    public string Transform(string? value)
    {
        var result = DataFaker.GetPrefixString(value);

        return result;
    }
}

