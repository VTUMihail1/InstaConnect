using System.Linq.Expressions;

using InstaConnect.Common.Application.Features.Validations.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.Strings.TooShort;

internal class TooShortStringMessageTransformer : IStringMessageTransformer
{
	private readonly int _minLength;

	public TooShortStringMessageTransformer(int minLength)
	{
		_minLength = minLength;
	}

	public string Transform<T>(Expression<Func<T, string>> propertyExpression, string value)
	{
		return CommonErrorMessages.GetMinLength(propertyExpression.GetProperty(), value.Length, _minLength);
	}
}
