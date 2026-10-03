namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Builders;

public class GetAllUserClaimsQueryBuilderFactory
{
	public GetAllUserClaimsQueryBuilder Create(UserClaim userClaim)
	{
		return new(userClaim);
	}
}
