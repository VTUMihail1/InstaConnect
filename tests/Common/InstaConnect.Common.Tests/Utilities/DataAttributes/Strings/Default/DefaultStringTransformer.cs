using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Default;

internal class DefaultStringTransformer : IStringTransformer
{
    public string Transform(string? value)
    {
        return value!;
    }
}

