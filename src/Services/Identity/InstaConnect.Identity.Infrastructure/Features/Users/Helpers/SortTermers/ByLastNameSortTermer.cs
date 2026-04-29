using System.Linq.Expressions;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.SortTermers;

public class ByLastNameSortTermer : IUsersSortTermer
{
	public UsersSortTerm SortTerm => UsersSortTerm.ByLastName;

	public Expression<Func<UserResponse, object>> Term => p => p.LastName;
}
