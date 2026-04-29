namespace InstaConnect.Follows.Presentation.Tests.Features.Users.Builders;

public class UserAddedEventRequestBuilderFactory
{
	public UserAddedEventRequestBuilder Create(User user)
	{
		return new(user);
	}
}
