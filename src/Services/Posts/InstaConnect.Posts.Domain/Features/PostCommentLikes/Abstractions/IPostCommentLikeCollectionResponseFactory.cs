using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

internal interface IPostCommentLikeCollectionResponseFactory
{
	public PostCommentLikeCollectionResponse Create(
		PostCommentResponse? postComment,
		ICollection<PostCommentLikeResponse> postCommentLikes,
		long totalCount,
		PostCommentLikesPaginationQuery pagination);

	public PostCommentLikeCollectionResponse CreateForUser(
		UserResponse? user,
		ICollection<PostCommentLikeResponse> postCommentLikes,
		long totalCount,
		PostCommentLikesPaginationQuery pagination);
}
