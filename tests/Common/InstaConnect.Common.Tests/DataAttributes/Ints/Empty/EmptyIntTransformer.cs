using InstaConnect.Common.Tests.DataAttributes.Ints.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Ints.Empty;

internal class EmptyIntTransformer : IIntTransformer
{
    public int Transform(int value)
    {
        return default;
    }
}
