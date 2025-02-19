using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;

namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowFactory
{
    public Follow Get(string followerId, string followingId);
}
