namespace InstaConnect.Identity.Application.Tests.Features.Users.Builders;

public class GetUserByIdQueryRequestBuilderFactory
{
	public GetUserByIdQueryRequestBuilder Create(User user)
	{
		return new(user);
	}
}
