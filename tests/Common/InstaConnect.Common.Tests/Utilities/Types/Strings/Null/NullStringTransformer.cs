using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;

namespace InstaConnect.Common.Tests.Utilities.Types.Strings.Null;

internal class NullStringTransformer : IStringTransformer
{
    public string Transform(string? value)
    {
        return null!;
    }
}

