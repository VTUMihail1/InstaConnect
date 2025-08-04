using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Base;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Default;

internal class DefaultIntTransformer : IIntTransformer
{
    public int Transform(int value)
    {
        return value;
    }
}

