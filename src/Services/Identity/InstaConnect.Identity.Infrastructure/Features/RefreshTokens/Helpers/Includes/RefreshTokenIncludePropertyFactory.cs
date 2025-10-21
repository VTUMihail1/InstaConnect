using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Extensions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.RefreshTokens.Domain.Features.RefreshTokens.Exceptions;
using InstaConnect.RefreshTokens.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.RefreshTokens.Infrastructure.Features.RefreshTokens.Abstractions;

namespace InstaConnect.Common.Infrastructure.RefreshTokenSortPropertys;
internal class RefreshTokenIncludePropertyFactory : IRefreshTokenIncludePropertyFactory
{
    private readonly IEnumerable<IRefreshTokenIncludeProperty> _refreshTokenIncludeProperty;

    public RefreshTokenIncludePropertyFactory(IEnumerable<IRefreshTokenIncludeProperty> refreshTokenIncludeProperty)
    {
        _refreshTokenIncludeProperty = refreshTokenIncludeProperty;
    }

    public ICollection<IRefreshTokenIncludeProperty> Create(ICollection<RefreshTokenIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _refreshTokenIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new RefreshTokenIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties.ToList();
    }
}
