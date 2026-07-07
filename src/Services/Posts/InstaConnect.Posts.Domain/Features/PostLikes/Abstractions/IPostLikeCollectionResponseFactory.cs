using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

public interface IPostLikeCollectionResponseFactory
{
	public PostLikeCollectionResponse Create(
		PostResponse? post,
		ICollection<PostLikeResponse> postLikes,
		long totalCount,
		PostLikesPaginationQuery pagination);

	public PostLikeCollectionResponse CreateForUser(
		UserResponse? user,
		ICollection<PostLikeResponse> postLikes,
		long totalCount,
		PostLikesPaginationQuery pagination);
}
