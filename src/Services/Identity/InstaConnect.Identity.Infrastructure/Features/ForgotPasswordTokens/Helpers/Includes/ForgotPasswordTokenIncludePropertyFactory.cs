using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Extensions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.ForgotPasswordTokens.Domain.Features.ForgotPasswordTokens.Exceptions;
using InstaConnect.ForgotPasswordTokens.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.ForgotPasswordTokens.Infrastructure.Features.ForgotPasswordTokens.Abstractions;

namespace InstaConnect.Common.Infrastructure.ForgotPasswordTokenSortPropertys;
internal class ForgotPasswordTokenIncludePropertyFactory : IForgotPasswordTokenIncludePropertyFactory
{
    private readonly IEnumerable<IForgotPasswordTokenIncludeProperty> _forgotPasswordTokenIncludeProperty;

    public ForgotPasswordTokenIncludePropertyFactory(IEnumerable<IForgotPasswordTokenIncludeProperty> forgotPasswordTokenIncludeProperty)
    {
        _forgotPasswordTokenIncludeProperty = forgotPasswordTokenIncludeProperty;
    }

    public ICollection<IForgotPasswordTokenIncludeProperty> Create(ICollection<ForgotPasswordTokenIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _forgotPasswordTokenIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new ForgotPasswordTokenIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties.ToList();
    }
}
