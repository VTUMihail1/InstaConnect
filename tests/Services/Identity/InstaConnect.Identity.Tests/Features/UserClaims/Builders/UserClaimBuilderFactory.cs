namespace InstaConnect.Identity.Tests.Features.UserClaims.Builders;

public class UserClaimBuilderFactory
{
	public UserClaimBuilder Create(User user)
	{
		return new(user);
	}
}
