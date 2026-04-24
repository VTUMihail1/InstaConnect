using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;
using InstaConnect.Common.Tests.Features.Utilities;

namespace InstaConnect.Common.Tests.Features.DataAttributes.Enums.Empty;

internal class EmptyEnumTransformer<TEnum> : IEnumTransformer<TEnum>
        where TEnum : Enum
{
    public TEnum Transform(TEnum value)
    {
        var result = DataFaker.GetEmptyEnum<TEnum>();

        return result;
    }
}

