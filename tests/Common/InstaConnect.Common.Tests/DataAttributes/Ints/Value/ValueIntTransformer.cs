using InstaConnect.Common.Tests.DataAttributes.Ints.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Ints.Value;

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

