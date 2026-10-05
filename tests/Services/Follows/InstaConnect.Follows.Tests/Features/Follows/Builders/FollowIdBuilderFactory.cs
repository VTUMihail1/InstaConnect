using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;

namespace InstaConnect.Follows.Tests.Features.Follows.Builders;

public class FollowIdBuilderFactory
{
	public FollowIdBuilder Create(FollowId id)
	{
		return new(id);
	}
}
