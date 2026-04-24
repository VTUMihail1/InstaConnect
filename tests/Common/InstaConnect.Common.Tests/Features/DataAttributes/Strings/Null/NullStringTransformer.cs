using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.Null;

internal class NullStringTransformer : IStringTransformer
{
    public string Transform(string? value)
    {
        return null!;
    }
}

