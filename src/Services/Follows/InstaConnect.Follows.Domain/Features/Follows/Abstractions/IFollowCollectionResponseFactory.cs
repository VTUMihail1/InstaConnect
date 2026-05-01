using InstaConnect.Follows.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

internal interface IFollowCollectionResponseFactory
{
	public FollowCollectionResponse Create(UserResponse follower, ICollection<FollowResponse> follows, long totalCount, FollowsPaginationQuery pagination);

	public FollowCollectionResponse CreateForFollowing(UserResponse following, ICollection<FollowResponse> follows, long totalCount, FollowsPaginationQuery pagination);
}
