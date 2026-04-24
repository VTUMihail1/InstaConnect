using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Common.Tests.Features.Utilities;

namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.NotEqual;

internal class NotEqualStringTransformer : IStringTransformer
{
    public string Transform(string? value)
    {
        var result = DataFaker.GetString();

        return result;
    }
}

