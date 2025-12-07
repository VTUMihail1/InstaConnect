using System.Linq.Expressions;

using InstaConnect.Common.Application.Utilities;
using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Tests.DataAttributes.Strings.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Strings.Null;

internal class NullStringMessageTransformer : IStringMessageTransformer
{
    public string Transform<T>(Expression<Func<T, string>> propertyExpression, string value)
    {
        return CommonErrorMessages.GetEmpty(propertyExpression.GetProperty());
    }
}
