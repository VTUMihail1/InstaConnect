using System.Linq.Expressions;

using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;
using InstaConnect.Users.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class ByUserNameSortProperty : IUserSortProperty
{
    public UserSortProperty SortProperty => UserSortProperty.ByName;

    public Expression<Func<User, object>> Property => p => p.Name;
}
