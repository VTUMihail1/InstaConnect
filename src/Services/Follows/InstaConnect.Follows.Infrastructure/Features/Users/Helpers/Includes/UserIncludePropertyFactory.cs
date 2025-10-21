using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Extensions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.Users.Domain.Features.Users.Exceptions;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;
using InstaConnect.Users.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Common.Infrastructure.UserSortPropertys;
internal class UserIncludePropertyFactory : IUserIncludePropertyFactory
{
    private readonly IEnumerable<IUserIncludeProperty> _followIncludeProperties;

    public UserIncludePropertyFactory(IEnumerable<IUserIncludeProperty> followIncludeProperties)
    {
        _followIncludeProperties = followIncludeProperties;
    }

    public ICollection<IUserIncludeProperty> Create(ICollection<UserIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _followIncludeProperties.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new UserIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties.ToList();
    }
}
