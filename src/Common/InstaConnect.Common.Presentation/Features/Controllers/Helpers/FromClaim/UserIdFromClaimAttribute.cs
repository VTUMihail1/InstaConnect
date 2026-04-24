using InstaConnect.Common.Domain.Features.Tokens.Utilities;

namespace InstaConnect.Common.Presentation.Features.Controllers.Helpers.FromClaim;

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
public sealed class UserIdFromClaimAttribute : FromClaimAttribute
{
    public UserIdFromClaimAttribute() : base(DefaultClaims.Id)
    {

    }
}
