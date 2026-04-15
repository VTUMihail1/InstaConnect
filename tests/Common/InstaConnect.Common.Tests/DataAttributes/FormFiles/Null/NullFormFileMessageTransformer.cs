using System.Linq.Expressions;

using InstaConnect.Common.Application.Utilities;
using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Tests.DataAttributes.FormFiles.Base;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Tests.DataAttributes.FormFiles.Null;

internal class NullFormFileMessageTransformer : IFormFileMessageTransformer
{
    public string Transform<T>(Expression<Func<T, IFormFile>> propertyExpression, IFormFile value)
    {
        return CommonErrorMessages.GetEmpty(propertyExpression.GetProperty());
    }
}
