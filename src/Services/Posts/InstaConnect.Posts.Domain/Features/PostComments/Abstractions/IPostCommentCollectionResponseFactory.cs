using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

internal interface IPostCommentCollectionResponseFactory
{
	public PostCommentCollectionResponse Create(
        PostResponse? post,
        ICollection<PostCommentResponse> postComments,
        long totalCount,
        PostCommentsPaginationQuery pagination);

	public PostCommentCollectionResponse CreateForUser(
        UserResponse? user,
        ICollection<PostCommentResponse> postComments,
        long totalCount,
        PostCommentsPaginationQuery pagination);
}
