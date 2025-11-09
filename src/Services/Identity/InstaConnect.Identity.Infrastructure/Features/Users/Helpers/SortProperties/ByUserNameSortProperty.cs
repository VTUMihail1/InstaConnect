using System.Linq.Expressions;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.SortProperties;

public class ByUserNameSortProperty : IUserSortProperty
{
    public UserSortProperty SortProperty => UserSortProperty.ByName;

    public Expression<Func<User, object>> Property => p => p.Name;
}
