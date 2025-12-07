using System.Linq.Expressions;

using InstaConnect.Common.Application.Utilities;
using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Tests.DataAttributes.Ints.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Ints.TooLarge;

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
