using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Base;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Value;

internal class ValueIntTransformer : IIntTransformer
{
    private readonly int _value;

    public ValueIntTransformer(int value)
    {
        _value = value;
    }

    public int Transform(int value)
    {
        return _value;
    }
}

