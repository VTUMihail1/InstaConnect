namespace InstaConnect.Identity.Application.Tests.Features.Users.Builders;

public class GetUserDetailsByIdQueryRequestBuilderFactory
{
	public GetUserDetailsByIdQueryRequestBuilder Create(User user)
	{
		return new(user);
	}
}
