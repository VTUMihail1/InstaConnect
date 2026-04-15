using InstaConnect.Common.Tests.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.Null;

internal class NullStringTransformer : IStringTransformer
{
    public string Transform(string? value)
    {
        return null!;
    }
}

