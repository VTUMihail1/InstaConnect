namespace InstaConnect.Posts.Infrastructure.Tests.Features.Common.Builders;

public class CurrentUserQueryBuilderFactory
{
	public CurrentUserQueryBuilder Create(User user)
	{
		return new(user);
	}
}
