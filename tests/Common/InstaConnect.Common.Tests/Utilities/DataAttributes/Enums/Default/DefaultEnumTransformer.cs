using InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Base;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Default;

internal class DefaultEnumTransformer<TEnum> : IEnumTransformer<TEnum>
        where TEnum : Enum
{
    public TEnum Transform(TEnum value)
    {
        return value;
    }
}

