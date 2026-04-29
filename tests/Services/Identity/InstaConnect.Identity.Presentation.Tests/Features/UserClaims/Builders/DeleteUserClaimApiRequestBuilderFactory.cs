namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Builders;

public class DeleteUserClaimApiRequestBuilderFactory
{
	public DeleteUserClaimApiRequestBuilder Create(UserClaim userClaim)
	{
		return new(userClaim);
	}
}
