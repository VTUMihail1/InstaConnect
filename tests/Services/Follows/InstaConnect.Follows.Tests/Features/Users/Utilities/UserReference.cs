using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Tests.Features.Users.Utilities;

public static class UserReference
{
	extension(User? user)
	{
		public User? SetFollowFollowers()
		{
			user?.FollowFollowers.ForEach(e => e.AddFollowing(user).SetFollower());

			return user;
		}

		public User? SetFollowFollowings()
		{
			user?.FollowFollowings.ForEach(e => e.AddFollower(user).SetFollowing());

			return user;
		}
	}
}
