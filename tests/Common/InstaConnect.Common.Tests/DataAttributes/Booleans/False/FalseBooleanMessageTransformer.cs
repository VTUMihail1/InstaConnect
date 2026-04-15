using System.Linq.Expressions;

using InstaConnect.Common.Application.Utilities;
using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Tests.DataAttributes.Booleans.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Booleans.False;

internal class FalseBooleanMessageTransformer : IBooleanMessageTransformer
{
    public string Transform<T>(Expression<Func<T, bool>> propertyExpression, bool value)
    {
        return CommonErrorMessages.GetEmpty(propertyExpression.GetProperty());
    }
}
