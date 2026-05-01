namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Builders;

public class AddUserClaimApiRequestBuilderFactory
{
	public AddUserClaimApiRequestBuilder Create(User user)
	{
		return new(user);
	}
}
