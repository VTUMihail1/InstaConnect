using System.Linq.Expressions;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.SortProperties;

public class ByUserLastNameSortProperty : IUserSortProperty
{
    public UserSortProperty SortTerm => UserSortProperty.ByLastName;

    public Expression<Func<UserResponse, object>> Term => p => p.LastName;
}
