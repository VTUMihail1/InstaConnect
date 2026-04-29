using System.Linq.Expressions;

using InstaConnect.Common.Application.Features.Validations.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Booleans.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.Booleans.False;

internal class FalseBooleanMessageTransformer : IBooleanMessageTransformer
{
	public string Transform<T>(Expression<Func<T, bool>> propertyExpression, bool value)
	{
		return CommonErrorMessages.GetEmpty(propertyExpression.GetProperty());
	}
}
