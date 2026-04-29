using System.Linq.Expressions;

using InstaConnect.Common.Application.Features.Validations.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.TooLong;

internal class TooLongStringMessageTransformer : IStringMessageTransformer
{
	private readonly int _maxLength;

	public TooLongStringMessageTransformer(int maxLength)
	{
		_maxLength = maxLength;
	}

	public string Transform<T>(Expression<Func<T, string>> propertyExpression, string value)
	{
		return CommonErrorMessages.GetMaxLength(propertyExpression.GetProperty(), value.Length, _maxLength);
	}
}
