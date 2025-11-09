using InstaConnect.Common.Tests.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Utilities;

namespace InstaConnect.Common.Tests.DataAttributes.Enums.Empty;

internal class EmptyEnumTransformer<TEnum> : IEnumTransformer<TEnum>
        where TEnum : Enum
{
    public TEnum Transform(TEnum value)
    {
        var result = DataFaker.GetEmptyEnum<TEnum>();

        return result;
    }
}

