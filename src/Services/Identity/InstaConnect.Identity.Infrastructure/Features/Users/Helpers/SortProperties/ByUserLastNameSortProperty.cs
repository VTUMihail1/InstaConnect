using System.Linq.Expressions;

using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Users.Infrastructure.Features.Users.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class ByUserLastNameSortProperty : IUserSortProperty
{
    public UserSortProperty SortProperty => UserSortProperty.ByLastName;

    public Expression<Func<User, object>> Property => p => p.LastName;
}
