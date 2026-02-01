using System.Linq.Expressions;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.SortProperties;

public class ByUserCreatedAtSortProperty : IUserSortProperty
{
    public UserSortProperty SortTerm => UserSortProperty.ByCreatedAt;

    public Expression<Func<UserResponse, object>> Term => p => p.CreatedAtUtc;
}
