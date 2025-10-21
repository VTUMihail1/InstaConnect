using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Extensions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.EmailConfirmationTokens.Domain.Features.EmailConfirmationTokens.Exceptions;
using InstaConnect.EmailConfirmationTokens.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.EmailConfirmationTokens.Infrastructure.Features.EmailConfirmationTokens.Abstractions;

namespace InstaConnect.Common.Infrastructure.EmailConfirmationTokenSortPropertys;
internal class EmailConfirmationTokenIncludePropertyFactory : IEmailConfirmationTokenIncludePropertyFactory
{
    private readonly IEnumerable<IEmailConfirmationTokenIncludeProperty> _emailConfirmationTokenIncludeProperty;

    public EmailConfirmationTokenIncludePropertyFactory(IEnumerable<IEmailConfirmationTokenIncludeProperty> emailConfirmationTokenIncludeProperty)
    {
        _emailConfirmationTokenIncludeProperty = emailConfirmationTokenIncludeProperty;
    }

    public ICollection<IEmailConfirmationTokenIncludeProperty> Create(ICollection<EmailConfirmationTokenIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _emailConfirmationTokenIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new EmailConfirmationTokenIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties.ToList();
    }
}
