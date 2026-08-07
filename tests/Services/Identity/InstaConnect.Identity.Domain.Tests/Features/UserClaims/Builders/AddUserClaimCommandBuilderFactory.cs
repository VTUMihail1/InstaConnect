namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Builders;

public class AddUserClaimCommandBuilderFactory
{
	public AddUserClaimCommandBuilder Create(User user)
	{
		return new(user);
	}
}
