using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Null;

internal class NullStringTransformer : IStringTransformer
{
    public string Transform(string? value)
    {
        return null!;
    }
}

