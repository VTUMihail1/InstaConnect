namespace InstaConnect.Follows.Tests.Features.Follows.Utilities;

public static class FollowGenerator
{
	extension(Follow baseFollow)
	{
		public ICollection<Follow> Generate(IEnumerable<User> followers, IEnumerable<User> followings)
		{
			return [.. followers
			  .SelectMany(follower =>
				  followings.Select(followings =>
				  {
					  var follow = new Follow(
						  new(follower.Id, followings.Id),
						  FollowDataFaker.GetCreatedAtUtc());

					  if(baseFollow.Id == follow.Id)
					  {
						  return baseFollow;
					  }

					  followings.AddFollowFollower(follow);
					  follower.AddFollowFollowing(follow);
					  follow.AddFollowing(followings);
					  follow.AddFollower(follower);

					  return follow;
				  }))];
		}
	}
}
