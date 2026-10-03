namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Builders;

public class DeleteUserClaimCommandBuilderFactory
{
	public DeleteUserClaimCommandBuilder Create(UserClaim userClaim)
	{
		return new(userClaim);
	}
}
