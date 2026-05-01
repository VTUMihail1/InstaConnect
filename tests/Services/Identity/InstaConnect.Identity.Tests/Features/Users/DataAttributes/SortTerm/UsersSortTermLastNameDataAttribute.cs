namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UsersSortTermLastNameDataAttribute
	: SortEnumDataAttribute<UsersSortTerm>
{
	public UsersSortTermLastNameDataAttribute()
		: base(UsersSortTerm.ByLastName)
	{
	}
}
