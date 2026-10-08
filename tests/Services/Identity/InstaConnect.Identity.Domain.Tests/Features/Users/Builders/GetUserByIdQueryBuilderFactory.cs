namespace InstaConnect.Identity.Domain.Tests.Features.Users.Builders;

public class GetUserByIdQueryBuilderFactory
{
	public GetUserByIdQueryBuilder Create(User user)
	{
		return new(user);
	}
}
