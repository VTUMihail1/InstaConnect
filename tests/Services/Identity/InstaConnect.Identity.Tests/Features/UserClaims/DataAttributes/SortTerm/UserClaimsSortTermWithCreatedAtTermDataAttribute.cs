namespace InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserClaimsSortTermWithCreatedAtTermDataAttribute
	: SortEnumWithAscendingTermDataAttribute<UserClaimsSortTerm, UserClaim, DateTimeOffset>
{
	public UserClaimsSortTermWithCreatedAtTermDataAttribute()
		: base(UserClaimsSortTerm.ByCreatedAt, p => p.CreatedAtUtc)
	{
	}
}
