using System.Linq.Expressions;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.SortProperties;

public class ByUserCreatedAtSortProperty : IUserSortProperty
{
    public UserSortProperty SortProperty => UserSortProperty.ByCreatedAt;

    public Expression<Func<User, object>> Property => p => p.CreatedAt;
}
