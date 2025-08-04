using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.DifferentCase;

internal class DifferentCaseStringTransformer : IStringTransformer
{
    public string Transform(string? value)
    {
        var result = DataFaker.GetDifferentCaseString(value);

        return result;
    }
}

