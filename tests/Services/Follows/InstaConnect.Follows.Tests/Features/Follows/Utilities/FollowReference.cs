namespace InstaConnect.Follows.Tests.Features.Follows.Utilities;

public static class FollowReference
{
	extension(ICollection<Follow> follows)
	{
		public ICollection<Follow> SetFollower()
		{
			foreach (var follow in follows)
			{
				follow.SetFollower();
			}

			return follows;
		}

		public ICollection<Follow> SetFollowing()
		{
			foreach (var follow in follows)
			{
				follow.SetFollowing();
			}

			return follows;
		}
	}
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
