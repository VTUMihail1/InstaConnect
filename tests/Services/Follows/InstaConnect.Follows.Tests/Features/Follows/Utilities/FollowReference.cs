namespace InstaConnect.Follows.Tests.Features.Follows.Utilities;

public static class FollowReference
{
	extension(Follow? follow)
	{
		public Follow? SetFollower()
		{
			follow?.Follower?.AddFollowFollowing(follow);

			return follow;
		}

		public Follow? SetFollowing()
		{
			follow?.Following?.AddFollowFollower(follow);

			return follow;
		}
	}
}
