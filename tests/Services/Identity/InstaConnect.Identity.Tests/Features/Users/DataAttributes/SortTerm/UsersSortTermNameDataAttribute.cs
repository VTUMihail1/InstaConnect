namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UsersSortTermNameDataAttribute
	: SortEnumDataAttribute<UsersSortTerm>
{
	public UsersSortTermNameDataAttribute()
		: base(UsersSortTerm.ByName)
	{
	}
}
