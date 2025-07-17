using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;

namespace InstaConnect.Common.Tests.Utilities.Types.Strings.Default;

internal class DefaultStringTransformer : IStringTransformer
{
    public string Transform(string? value)
    {
        return value!;
    }
}

