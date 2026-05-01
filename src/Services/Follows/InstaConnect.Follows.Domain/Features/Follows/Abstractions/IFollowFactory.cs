namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowFactory
{
	public Follow Create(UserId followerId, UserId followingId);
}
