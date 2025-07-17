using InstaConnect.Common.Tests.Utilities.Types.Ints.Base;

namespace InstaConnect.Common.Tests.Utilities.Types.Ints.Default;

internal class DefaultIntTransformer : IIntTransformer
{
    public int Transform(int value)
    {
        return value;
    }
}

