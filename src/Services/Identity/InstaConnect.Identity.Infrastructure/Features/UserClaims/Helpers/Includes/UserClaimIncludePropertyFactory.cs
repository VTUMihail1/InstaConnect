using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Extensions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.UserClaims.Domain.Features.UserClaims.Exceptions;
using InstaConnect.UserClaims.Domain.Features.UserClaims.Models.Requests;
using InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Abstractions;

namespace InstaConnect.Common.Infrastructure.UserClaimSortPropertys;
internal class UserClaimIncludePropertyFactory : IUserClaimIncludePropertyFactory
{
    private readonly IEnumerable<IUserClaimIncludeProperty> _userClaimIncludeProperty;

    public UserClaimIncludePropertyFactory(IEnumerable<IUserClaimIncludeProperty> userClaimIncludeProperty)
    {
        _userClaimIncludeProperty = userClaimIncludeProperty;
    }

    public ICollection<IUserClaimIncludeProperty> Create(ICollection<UserClaimIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _userClaimIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new UserClaimIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties.ToList();
    }
}
