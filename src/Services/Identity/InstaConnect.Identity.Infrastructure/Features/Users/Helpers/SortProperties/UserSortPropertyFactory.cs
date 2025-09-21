using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Infrastructure.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Common.Infrastructure.UserSortPropertys;
internal class UserSortPropertyFactory : IUserSortPropertyFactory
{
    private readonly IEnumerable<IUserSortProperty> _userSortProperty;

    public UserSortPropertyFactory(IEnumerable<IUserSortProperty> userSortProperty)
    {
        _userSortProperty = userSortProperty;
    }

    public IUserSortProperty Create(UserSortProperty sortProperty)
    {
        var property = _userSortProperty.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new UserSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}
