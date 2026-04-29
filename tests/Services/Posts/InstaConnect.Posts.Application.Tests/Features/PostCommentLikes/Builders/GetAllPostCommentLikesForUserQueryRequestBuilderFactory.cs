namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesForUserQueryRequestBuilderFactory
{
	public GetAllPostCommentLikesForUserQueryRequestBuilder Create(PostCommentLike postCommentLike)
	{
		return new(postCommentLike);
	}
}
