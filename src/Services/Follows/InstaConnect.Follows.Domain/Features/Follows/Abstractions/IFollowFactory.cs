using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;

namespace InstaConnect.FollowLikes.Domain.Features.FollowLikes.Abstractions;

public interface IFollowFactory
{
    public Follow Create(string followerId, string followingId);
}
