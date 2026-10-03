namespace InstaConnect.Follows.Domain.Features.Follows.Extensions;

public static class FollowCollectionExtensions
{
	extension(ICollection<Follow> follows)
	{
		public ICollection<Follow> AddFollower(User follower)
		{
			foreach (var follow in follows)
			{
				follow.AddFollower(follower);
			}

			return follows;
		}

		public ICollection<Follow> AddFollowing(User following)
		{
			foreach (var follow in follows)
			{
				follow.AddFollower(following);
			}

			return follows;
		}
	}
}
