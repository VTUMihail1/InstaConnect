using System.Linq.Expressions;

using InstaConnect.Common.Application.Features.Validations.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Ints.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.Ints.TooLarge;

internal class TooLargeIntMessageTransformer : IIntMessageTransformer
{
	private readonly int _maxValue;

	public TooLargeIntMessageTransformer(int maxValue)
	{
		_maxValue = maxValue;
	}

	public string Transform<T>(Expression<Func<T, int>> propertyExpression, int value)
	{
		return CommonErrorMessages.GetMaxValue(propertyExpression.GetProperty(), value, _maxValue);
	}
}
