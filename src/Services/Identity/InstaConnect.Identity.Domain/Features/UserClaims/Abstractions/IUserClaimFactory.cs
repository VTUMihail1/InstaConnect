using InstaConnect.Common.Domain.Utilities;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

internal interface IUserClaimFactory
{
    UserClaim Create(UserId id, ApplicationClaims claim);
}
