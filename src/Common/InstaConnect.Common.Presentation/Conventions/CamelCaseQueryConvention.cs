using InstaConnect.Common.Domain.Extensions;

using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InstaConnect.Common.Presentation.Conventions;
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
