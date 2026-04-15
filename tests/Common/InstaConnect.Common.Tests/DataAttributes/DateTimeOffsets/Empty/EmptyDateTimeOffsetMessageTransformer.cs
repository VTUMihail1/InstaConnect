using System.Linq.Expressions;

using InstaConnect.Common.Application.Utilities;
using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Tests.DataAttributes.DateTimeOffsets.Base;

namespace InstaConnect.Common.Tests.DataAttributes.DateTimeOffsets.Empty;

internal class EmptyDateTimeOffsetMessageTransformer : IDateTimeOffsetMessageTransformer
{
    public string Transform<T>(Expression<Func<T, DateTimeOffset>> propertyExpression, DateTimeOffset value)
    {
        return CommonErrorMessages.GetEmpty(propertyExpression.GetProperty());
    }
}
