using InstaConnect.Common.Tests.Utilities.Types.Ints.Base;

namespace InstaConnect.Common.Tests.Utilities.Types.Ints.Value;

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

