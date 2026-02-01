using System.Linq.Expressions;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.SortProperties;

public class ByUserNameSortProperty : IUserSortProperty
{
    public UserSortProperty SortTerm => UserSortProperty.ByName;

    public Expression<Func<UserResponse, object>> Term => p => p.Name.Value;
}
