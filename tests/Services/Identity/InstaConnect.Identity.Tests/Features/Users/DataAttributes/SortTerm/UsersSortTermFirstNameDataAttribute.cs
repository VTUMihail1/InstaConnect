namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UsersSortTermFirstNameDataAttribute
	: SortEnumDataAttribute<UsersSortTerm>
{
	public UsersSortTermFirstNameDataAttribute()
		: base(UsersSortTerm.ByFirstName)
	{
	}
}
