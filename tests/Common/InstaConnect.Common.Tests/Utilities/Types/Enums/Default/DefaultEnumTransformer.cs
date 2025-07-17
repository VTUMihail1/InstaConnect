using InstaConnect.Common.Tests.Utilities.Types.Enums.Base;

namespace InstaConnect.Common.Tests.Utilities.Types.Enums.Default;

internal class DefaultEnumTransformer<TEnum> : IEnumTransformer<TEnum>
        where TEnum : Enum
{
    public TEnum Transform(TEnum value)
    {
        return value;
    }
}

