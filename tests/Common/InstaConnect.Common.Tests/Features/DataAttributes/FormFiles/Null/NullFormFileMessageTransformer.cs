using System.Linq.Expressions;

using InstaConnect.Common.Application.Features.Validations.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Null;

internal class NullFormFileMessageTransformer : IFormFileMessageTransformer
{
	public string Transform<T>(Expression<Func<T, IFormFile>> propertyExpression, IFormFile value)
	{
		return CommonErrorMessages.GetEmpty(propertyExpression.GetProperty());
	}
}
