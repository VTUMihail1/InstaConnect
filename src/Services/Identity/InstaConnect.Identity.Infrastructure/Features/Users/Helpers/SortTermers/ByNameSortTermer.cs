using System.Linq.Expressions;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.SortTermers;

public class ByNameSortTermer : IUsersSortTermer
{
	public UsersSortTerm SortTerm => UsersSortTerm.ByName;

	public Expression<Func<UserResponse, object>> Term => p => p.Name.Value;
}
