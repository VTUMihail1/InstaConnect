using InstaConnect.Common.Domain.Utilities;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.ValueObjects;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public static class UserClaimEquals
{
    extension(UserClaimId p)
    {
        public bool Matches(string id, ApplicationClaims claim)
        {
            return p.Id.Matches(id) &&
                   p.Claim == claim;
        }
    }
}
