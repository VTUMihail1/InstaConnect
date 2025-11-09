using System.Linq.Expressions;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.SortProperties;

public class ByUserFirstNameSortProperty : IUserSortProperty
{
    public UserSortProperty SortProperty => UserSortProperty.ByFirstName;

    public Expression<Func<User, object>> Property => p => p.FirstName;
}
