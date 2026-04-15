using InstaConnect.Common.Tests.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.Empty;

internal class EmptyStringTransformer : IStringTransformer
{
    public string Transform(string? value)
    {
        return string.Empty;
    }
}

