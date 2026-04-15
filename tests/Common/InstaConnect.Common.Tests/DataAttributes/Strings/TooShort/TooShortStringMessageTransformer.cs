using System.Linq.Expressions;

using InstaConnect.Common.Application.Utilities;
using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Tests.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.TooShort;

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
