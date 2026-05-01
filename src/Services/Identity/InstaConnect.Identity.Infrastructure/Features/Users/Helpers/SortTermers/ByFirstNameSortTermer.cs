using System.Linq.Expressions;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.SortTermers;

public class ByFirstNameSortTermer : IUsersSortTermer
{
	public UsersSortTerm SortTerm => UsersSortTerm.ByFirstName;

	public Expression<Func<UserResponse, object>> Term => p => p.FirstName;
}
