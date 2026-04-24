using System.Linq.Expressions;

using InstaConnect.Common.Application.Features.Validations.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Ints.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.Ints.TooSmall;

internal class TooSmallIntMessageTransformer : IIntMessageTransformer
{
    private readonly int _minValue;

    public TooSmallIntMessageTransformer(int minValue)
    {
        _minValue = minValue;
    }

    public string Transform<T>(Expression<Func<T, int>> propertyExpression, int value)
    {
        return CommonErrorMessages.GetMinValue(propertyExpression.GetProperty(), value, _minValue);
    }
}
