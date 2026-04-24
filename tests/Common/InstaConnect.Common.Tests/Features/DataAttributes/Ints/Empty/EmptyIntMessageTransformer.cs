using System.Linq.Expressions;

using InstaConnect.Common.Application.Features.Validations.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Ints.Base;

namespace InstaConnect.Common.Tests.Features.DataAttributes.Ints.Empty;

internal class EmptyIntMessageTransformer : IIntMessageTransformer
{
    public string Transform<T>(Expression<Func<T, int>> propertyExpression, int value)
    {
        return CommonErrorMessages.GetEmpty(propertyExpression.GetProperty());
    }
}
