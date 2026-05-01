using System.Linq.Expressions;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.SortTermers;

public class ByCreatedAtSortTerner : IUsersSortTermer
{
	public UsersSortTerm SortTerm => UsersSortTerm.ByCreatedAt;

	public Expression<Func<UserResponse, object>> Term => p => p.CreatedAtUtc;
}
