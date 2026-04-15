using System.Linq.Expressions;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.SortTermers;

public class ByCreatedAtSortTerner : IUserClaimsSortTermer
{
    public UserClaimsSortTerm SortTerm => UserClaimsSortTerm.ByCreatedAt;

    public Expression<Func<UserClaimResponse, object>> Term => p => p.CreatedAtUtc;
}
