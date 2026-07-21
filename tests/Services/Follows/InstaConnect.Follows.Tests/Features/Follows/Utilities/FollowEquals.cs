using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;
using InstaConnect.Follows.Events.Features.Follows;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Tests.Features.Follows.Utilities;

public static class FollowEquals
{
	extension(Follow? entity)
	{
		public bool Matches(FollowEventRequest request)
		{
			return entity != null &&
				   entity.Id.Matches(request.FollowerId, request.FollowingId) &&
				   entity.Follower.Matches(request.Follower) &&
				   entity.Following.Matches(request.Following) &&
				   entity.CreatedAtUtc == request.CreatedAtUtc;
		}

		public bool Matches(FollowNotificationRequest request)
		{
			return entity != null &&
				   entity.Id.Matches(request.FollowerId, request.FollowingId) &&
				   entity.Follower.Matches(request.Follower) &&
				   entity.Following.Matches(request.Following) &&
				   entity.CreatedAtUtc == request.CreatedAtUtc;
		}
	}

	extension(Follow entity)
	{
		public bool Matches(Follow follow)
		{
			return entity.Id.Matches(follow.Id) &&
				   entity.CreatedAtUtc == follow.CreatedAtUtc;
		}
	}

	extension(FollowId p)
	{
		public bool Matches(FollowId id)
		{
			return p.Matches(id.FollowerId.Id, id.FollowingId.Id);
		}

		public bool Matches(string followerId, string followingId)
		{
			return p.FollowerId.Matches(followerId) &&
				   p.FollowingId.Matches(followingId);
		}
	}
}
