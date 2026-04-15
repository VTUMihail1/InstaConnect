namespace InstaConnect.Identity.Tests.Features.UserClaims.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class UserClaimsSortTermCreatedAtDataAttribute
    : SortEnumDataAttribute<UserClaimsSortTerm>
{
    public UserClaimsSortTermCreatedAtDataAttribute()
        : base(UserClaimsSortTerm.ByCreatedAt)
    {
    }
}
