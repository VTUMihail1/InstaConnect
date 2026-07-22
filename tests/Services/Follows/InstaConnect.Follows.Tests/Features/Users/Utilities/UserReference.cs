using InstaConnect.Common.Domain.Features.Common.Extensions;

namespace InstaConnect.Follows.Tests.Features.Users.Utilities;

public static class UserReference
{
	extension(User? user)
	{
		public User? SetFollowFollowers()
		{
			user?.FollowFollowers.ForEach(e => e.AddFollowing(user));

			return user;
		}

		public User? SetFollowFollowings()
		{
			user?.FollowFollowings.ForEach(e => e.AddFollower(user));

			return user;
		}
	}
}
