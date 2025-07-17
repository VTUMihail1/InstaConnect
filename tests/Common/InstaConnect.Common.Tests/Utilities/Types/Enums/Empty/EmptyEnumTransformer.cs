using InstaConnect.Common.Tests.Utilities.Types.Enums.Base;

namespace InstaConnect.Common.Tests.Utilities.Types.Enums.Empty;

internal class EmptyEnumTransformer<TEnum> : IEnumTransformer<TEnum>
        where TEnum : Enum
{
    public TEnum Transform(TEnum value)
    {
        var result = DataFaker.GetEmptyEnum<TEnum>();

        return result;
    }
}

