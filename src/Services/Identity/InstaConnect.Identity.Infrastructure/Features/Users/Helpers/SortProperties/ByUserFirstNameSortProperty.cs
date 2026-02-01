using System.Linq.Expressions;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.SortProperties;

public class ByUserFirstNameSortProperty : IUserSortProperty
{
    public UserSortProperty SortTerm => UserSortProperty.ByFirstName;

    public Expression<Func<UserResponse, object>> Term => p => p.FirstName;
}
