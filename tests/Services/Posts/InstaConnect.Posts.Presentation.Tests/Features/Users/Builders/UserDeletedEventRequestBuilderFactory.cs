namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Builders;

public class UserDeletedEventRequestBuilderFactory
{
	public UserDeletedEventRequestBuilder Create(User user)
	{
		return new(user);
	}
}
