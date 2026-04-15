using InstaConnect.Common.Tests.DataAttributes.Strings.Base;
using InstaConnect.Common.Tests.Utilities;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.DifferentCase;

public class DifferentCaseStringTransformer : IStringTransformer
{
    public string Transform(string? value)
    {
        var result = DataFaker.GetDifferentCaseString(value);

        return result;
    }
}

