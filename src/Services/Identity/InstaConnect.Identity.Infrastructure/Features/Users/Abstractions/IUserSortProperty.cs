using System.Linq.Expressions;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

public interface IUserSortProperty
{
    public UserSortProperty SortProperty { get; }

    public Expression<Func<User, object>> Property { get; }
}
