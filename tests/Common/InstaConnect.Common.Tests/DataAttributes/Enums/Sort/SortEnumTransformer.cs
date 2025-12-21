using InstaConnect.Common.Tests.DataAttributes.Enums.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Enums.Sort;

internal class SortEnumTransformer<TEnum> : IEnumTransformer<TEnum>
        where TEnum : Enum
{
    private readonly TEnum _value;

    public SortEnumTransformer(TEnum value)
    {
        _value = value;
    }

    public TEnum Transform(TEnum value)
    {
        return _value;
    }
}
