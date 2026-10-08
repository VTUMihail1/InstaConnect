using System.Linq.Expressions;

using InstaConnect.Common.Domain.Features.Validations.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.InvalidEmail;

internal class InvalidEmailStringMessageTransformer : IStringMessageTransformer
{
	public string Transform<T>(Expression<Func<T, string>> propertyExpression, string value)
	{
		return CommonValidationErrorMessages.GetInvalidEmail(propertyExpression.GetPropertyDisplayName());
	}
}
