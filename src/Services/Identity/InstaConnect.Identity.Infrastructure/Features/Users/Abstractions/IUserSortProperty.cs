using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Users.Infrastructure.Features.Users.Abstractions;

public interface IUserSortProperty
{
    public UserSortProperty SortProperty { get; }

    public Expression<Func<User, object>> Property { get; }
}
