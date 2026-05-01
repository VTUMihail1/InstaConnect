namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Builders;

public class DeleteCurrentUserApiRequestBuilderFactory
{
	public DeleteCurrentUserApiRequestBuilder Create(User user)
	{
		return new(user);
	}
}
