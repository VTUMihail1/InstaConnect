namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UsersSortTermWithCreatedAtTermDataAttribute
	: SortEnumWithAscendingTermDataAttribute<UsersSortTerm, User, DateTimeOffset>
{
	public UsersSortTermWithCreatedAtTermDataAttribute()
		: base(UsersSortTerm.ByCreatedAt, p => p.CreatedAtUtc)
	{
	}
}
