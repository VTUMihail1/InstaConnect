using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Common.Tests.Features.Utilities;

namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.DifferentCase;

public class DifferentCaseStringTransformer : IStringTransformer
{
    public string Transform(string? value)
    {
        var result = DataFaker.GetDifferentCaseString(value);

        return result;
    }
}

