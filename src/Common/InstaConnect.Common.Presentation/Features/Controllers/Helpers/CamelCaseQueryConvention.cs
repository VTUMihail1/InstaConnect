using InstaConnect.Common.Domain.Features.Common.Extensions;

using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InstaConnect.Common.Presentation.Features.Controllers.Helpers;

public class CamelCaseQueryConvention : IParameterModelConvention
{
	public void Apply(ParameterModel parameter)
	{
		if (parameter.BindingInfo?.BindingSource != BindingSource.Query)
		{
			return;
		}

		if (parameter.BindingInfo == null)
		{
			parameter.BindingInfo = new BindingInfo();
		}

		parameter.BindingInfo.BinderModelName = parameter.ParameterName.ToCamelCase();
	}
}
