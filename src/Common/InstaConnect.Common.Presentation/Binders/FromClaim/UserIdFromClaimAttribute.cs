using InstaConnect.Common.Domain.Utilities;

namespace InstaConnect.Common.Presentation.Binders.FromClaim;

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
public sealed class UserIdFromClaimAttribute : FromClaimAttribute
{
    public UserIdFromClaimAttribute() : base(DefaultClaims.Id)
    {

    }
}
