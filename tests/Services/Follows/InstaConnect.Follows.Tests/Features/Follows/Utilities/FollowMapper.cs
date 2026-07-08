using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Tests.Features.Follows.Utilities;

public static class FollowMapper
{
	extension(Follow follow)
	{
		public FollowId ToId(
)
		{
			return follow.Id;
		}

		public Follow ToFull()
		{
			return new Follow(follow.Id,
					   follow.CreatedAtUtc)
				.AddFollower(follow.Follower?.ToFull())
				.AddFollowing(follow.Following?.ToFull());
		}

		public Follow ToWithoutFollower()
		{
			return new Follow(follow.Id,
					   follow.CreatedAtUtc)
				.AddFollowing(follow.Following?.ToFull());
		}

		public Follow ToWithoutFollowing()
		{
			return new Follow(follow.Id,
					   follow.CreatedAtUtc)
				.AddFollower(follow.Follower?.ToFull());
		}
	}
}
