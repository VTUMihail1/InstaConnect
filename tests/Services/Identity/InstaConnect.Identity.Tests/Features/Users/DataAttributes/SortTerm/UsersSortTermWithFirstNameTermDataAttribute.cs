namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UsersSortTermWithFirstNameTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<UsersSortTerm, User, string>
{
    public UsersSortTermWithFirstNameTermDataAttribute()
        : base(UsersSortTerm.ByFirstName, p => p.FirstName)
    {
    }
}
