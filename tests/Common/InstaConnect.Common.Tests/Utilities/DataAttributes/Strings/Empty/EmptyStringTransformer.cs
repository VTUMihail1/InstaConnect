using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Empty;

internal class EmptyStringTransformer : IStringTransformer
{
    public string Transform(string? value)
    {
        return string.Empty;
    }
}

