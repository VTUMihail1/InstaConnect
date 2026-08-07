namespace InstaConnect.Identity.Domain.Tests.Features.Users.Builders;

public class GetAllUsersQueryBuilderFactory
{
	public GetAllUsersQueryBuilder Create(User user)
	{
		return new(user);
	}
}
