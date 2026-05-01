namespace InstaConnect.Identity.Application.Tests.Features.Users.Builders;

public class GetAllUsersQueryRequestBuilderFactory
{
	public GetAllUsersQueryRequestBuilder Create(User user)
	{
		return new(user);
	}
}
