namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UsersSortTermCreatedAtDataAttribute
	: SortEnumDataAttribute<UsersSortTerm>
{
	public UsersSortTermCreatedAtDataAttribute()
		: base(UsersSortTerm.ByCreatedAt)
	{
	}
}
