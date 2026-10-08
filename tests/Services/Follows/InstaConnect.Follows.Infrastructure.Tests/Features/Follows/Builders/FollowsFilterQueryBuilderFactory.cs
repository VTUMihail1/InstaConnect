using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;

namespace InstaConnect.Follows.Infrastructure.Tests.Features.Follows.Builders;

public class FollowsFilterQueryBuilderFactory
{
	public FollowsFilterQueryBuilder Create(Follow follow)
	{
		return new(follow);
	}
}
