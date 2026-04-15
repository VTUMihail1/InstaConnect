using InstaConnect.Common.Tests.DataAttributes.Strings.Base;
using InstaConnect.Common.Tests.Utilities;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.NotEqual;

internal class NotEqualStringTransformer : IStringTransformer
{
    public string Transform(string? value)
    {
        var result = DataFaker.GetString();

        return result;
    }
}

