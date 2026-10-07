using System.Linq.Expressions;

using InstaConnect.Common.Domain.Features.Validations.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.Enums.Empty;

internal class EmptyEnumMessageTransformer<TEnum> : IEnumMessageTransformer<TEnum>
	where TEnum : Enum
{
	public string Transform<T>(Expression<Func<T, TEnum>> propertyExpression, TEnum value)
	{
		return CommonErrorMessages.GetEmpty(propertyExpression.GetPropertyDisplayName());
	}
}
