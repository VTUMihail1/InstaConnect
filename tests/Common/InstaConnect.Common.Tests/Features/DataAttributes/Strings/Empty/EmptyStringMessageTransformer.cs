using System.Linq.Expressions;

using InstaConnect.Common.Application.Features.Validations.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.Empty;

internal class EmptyStringMessageTransformer : IStringMessageTransformer
{
	public string Transform<T>(Expression<Func<T, string>> propertyExpression, string value)
	{
		return CommonErrorMessages.GetEmpty(propertyExpression.GetProperty());
	}
}
