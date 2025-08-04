using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Base;

namespace InstaConnect.Common.Tests.Utilities.DataAttributes.Enums.Empty;

internal class EmptyEnumTransformer<TEnum> : IEnumTransformer<TEnum>
        where TEnum : Enum
{
    public TEnum Transform(TEnum value)
    {
        var result = DataFaker.GetEmptyEnum<TEnum>();

        return result;
    }
}

