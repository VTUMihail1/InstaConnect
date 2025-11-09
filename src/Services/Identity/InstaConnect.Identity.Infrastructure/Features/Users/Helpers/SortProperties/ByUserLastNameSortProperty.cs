using System.Linq.Expressions;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.SortProperties;

public class ByUserLastNameSortProperty : IUserSortProperty
{
    public UserSortProperty SortProperty => UserSortProperty.ByLastName;

    public Expression<Func<User, object>> Property => p => p.LastName;
}
