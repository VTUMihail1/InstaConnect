using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;

namespace InstaConnect.Common.Tests.Utilities.Types.Strings.DifferentCase;

internal class DifferentCaseStringTransformer : IStringTransformer
{
    public string Transform(string? value)
    {
        var result = DataFaker.GetDifferentCaseString(value);

        return result;
    }
}

