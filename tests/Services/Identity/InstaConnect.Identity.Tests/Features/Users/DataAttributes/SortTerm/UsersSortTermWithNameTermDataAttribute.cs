namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UsersSortTermWithNameTermDataAttribute
	: SortEnumWithAscendingTermDataAttribute<UsersSortTerm, User, string>
{
	public UsersSortTermWithNameTermDataAttribute()
		: base(UsersSortTerm.ByName, p => p.Name.Value)
	{
	}
}
