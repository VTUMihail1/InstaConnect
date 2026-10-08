namespace InstaConnect.Identity.Infrastructure.Tests.Features.Users.Builders;

public class UsersFilterQueryBuilderFactory
{
	public UsersFilterQueryBuilder Create(User user)
	{
		return new(user);
	}
}
