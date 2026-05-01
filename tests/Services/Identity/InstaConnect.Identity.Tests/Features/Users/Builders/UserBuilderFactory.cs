namespace InstaConnect.Identity.Tests.Features.Users.Builders;

public class UserBuilderFactory
{
	public UserBuilder Create(string passwordHash, string? profileImage)
	{
		return new(passwordHash, profileImage);
	}
}
