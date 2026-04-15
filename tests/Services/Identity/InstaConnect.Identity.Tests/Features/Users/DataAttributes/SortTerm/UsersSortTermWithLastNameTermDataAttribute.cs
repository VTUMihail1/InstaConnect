namespace InstaConnect.Identity.Tests.Features.Users.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UsersSortTermWithLastNameTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<UsersSortTerm, User, string>
{
    public UsersSortTermWithLastNameTermDataAttribute()
        : base(UsersSortTerm.ByLastName, p => p.LastName)
    {
    }
}
