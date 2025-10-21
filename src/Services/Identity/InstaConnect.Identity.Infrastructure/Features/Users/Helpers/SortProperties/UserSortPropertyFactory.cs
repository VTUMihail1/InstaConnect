using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;
using InstaConnect.Users.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Common.Infrastructure.UserSortPropertys;
internal class UserSortPropertyFactory : IUserSortPropertyFactory
{
    private readonly IEnumerable<IUserSortProperty> _userSortProperties;

    public UserSortPropertyFactory(IEnumerable<IUserSortProperty> userSortProperties)
    {
        _userSortProperties = userSortProperties;
    }

    public IUserSortProperty Create(UserSortProperty sortProperty)
    {
        var property = _userSortProperties.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new UserSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}
