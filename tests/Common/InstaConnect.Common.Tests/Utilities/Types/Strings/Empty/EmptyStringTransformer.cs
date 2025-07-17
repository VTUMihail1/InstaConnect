using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;

namespace InstaConnect.Common.Tests.Utilities.Types.Strings.Empty;

internal class EmptyStringTransformer : IStringTransformer
{
    public string Transform(string? value)
    {
        return string.Empty;
    }
}

