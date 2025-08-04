using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Base;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Empty;

internal class EmptyIntTransformer : IIntTransformer
{
    public int Transform(int value)
    {
        return default;
    }
}

