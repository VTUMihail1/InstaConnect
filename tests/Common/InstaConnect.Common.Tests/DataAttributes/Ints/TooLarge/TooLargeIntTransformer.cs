using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Tests.DataAttributes.Ints.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Ints.TooLarge;

internal class TooLargeIntTransformer : IIntTransformer
{
    private readonly int _maxValue;

    public TooLargeIntTransformer(int maxValue)
    {
        _maxValue = maxValue;
    }

    public int Transform(int value)
    {
        return _maxValue.Increment();
    }
}

