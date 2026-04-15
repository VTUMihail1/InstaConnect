using System.Linq.Expressions;

using InstaConnect.Common.Application.Utilities;
using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Tests.DataAttributes.Ints.Base;

namespace InstaConnect.Common.Tests.DataAttributes.Ints.Empty;

internal class EmptyIntMessageTransformer : IIntMessageTransformer
{
    public string Transform<T>(Expression<Func<T, int>> propertyExpression, int value)
    {
        return CommonErrorMessages.GetEmpty(propertyExpression.GetProperty());
    }
}
