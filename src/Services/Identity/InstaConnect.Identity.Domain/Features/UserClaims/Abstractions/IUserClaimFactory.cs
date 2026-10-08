using InstaConnect.Common.Events.Features.AccessTokens.Models;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

public interface IUserClaimFactory
{
	public UserClaim Create(UserId id, ApplicationClaims claim);
}
