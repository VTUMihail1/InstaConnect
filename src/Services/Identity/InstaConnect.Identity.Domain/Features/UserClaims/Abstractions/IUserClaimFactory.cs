using InstaConnect.Common.Events.Features.Tokens.Models;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

internal interface IUserClaimFactory
{
	public UserClaim Create(UserId id, ApplicationClaims claim);
}
