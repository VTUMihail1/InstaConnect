namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowFactory
{
    public Follow Create(string followerId, string followingId);
}
