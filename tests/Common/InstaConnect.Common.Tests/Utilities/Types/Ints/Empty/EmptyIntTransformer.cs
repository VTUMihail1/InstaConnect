using InstaConnect.Common.Tests.Utilities.Types.Ints.Base;

namespace InstaConnect.Common.Tests.Utilities.Types.Ints.Empty;

internal class EmptyIntTransformer : IIntTransformer
{
    public int Transform(int value)
    {
        return default;
    }
}

