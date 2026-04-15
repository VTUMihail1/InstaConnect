using InstaConnect.Follows.Domain.Features.Follows.Models.ValueObjects;
using InstaConnect.Follows.Events.Features.Follows;
using InstaConnect.Follows.Tests.Features.Follows.Utilities;
using InstaConnect.Follows.Tests.Features.Users.Utilities;

namespace InstaConnect.Follows.Tests.Features.Follows.Utilities;

public static class FollowEquals
{
    extension(FollowAddedEventRequest request)
    {
        public bool Matches(Follow entity)
        {
            return entity.Matches(request.Follow);
        }
    }

    extension(FollowDeletedEventRequest request)
    {
        public bool Matches(Follow entity)
        {
            return entity.Matches(request.Follow);
        }
    }

    extension(FollowEventRequest r)
    {
        public bool Matches(FollowEventRequest request)
        {
            return r.FollowerId == request.FollowerId &&
                   r.FollowingId == request.FollowingId &&
                   r.Follower.Matches(request.Follower) &&
                   r.Following.Matches(request.Following) &&
                   r.CreatedAtUtc == request.CreatedAtUtc;
        }
    }

    extension(Follow entity)
    {
        public bool Matches(FollowEventRequest request)
        {
            return entity.Id.Matches(request.FollowerId, request.FollowingId) &&
                   entity.Follower != null && entity.Follower.Matches(request.Follower) &&
                   entity.Following != null && entity.Following.Matches(request.Following) &&
                   entity.CreatedAtUtc == request.CreatedAtUtc;
        }
    }

    extension(FollowId p)
    {
        public bool Matches(string followerId, string followingId)
        {
            return p.FollowerId.Matches(followerId) &&
                   p.FollowingId.Matches(followingId);
        }
    }
}
