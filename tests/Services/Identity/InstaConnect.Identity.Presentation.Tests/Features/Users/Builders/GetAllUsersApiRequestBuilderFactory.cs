namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Builders;

public class GetAllUsersApiRequestBuilderFactory
{
	public GetAllUsersApiRequestBuilder Create(User user)
	{
		return new(user);
	}
}
