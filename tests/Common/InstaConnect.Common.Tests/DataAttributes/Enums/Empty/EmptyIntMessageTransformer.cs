using System.Linq.Expressions;

using InstaConnect.Common.Application.Utilities;
using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Tests.DataAttributes.Enums.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Enums.Empty;

internal class EmptyEnumMessageTransformer<TEnum> : IEnumMessageTransformer<TEnum>
    where TEnum : Enum
{
    public string Transform<T>(Expression<Func<T, TEnum>> propertyExpression, TEnum value)
    {
        return CommonErrorMessages.GetEmpty(propertyExpression.GetProperty());
    }
}
