namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Builders;

public class DeleteUserApiRequestBuilderFactory
{
	public DeleteUserApiRequestBuilder Create(User user)
	{
		return new(user);
	}
}
