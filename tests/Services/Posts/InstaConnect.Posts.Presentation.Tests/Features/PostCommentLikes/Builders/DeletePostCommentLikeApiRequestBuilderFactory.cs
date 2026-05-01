namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class DeletePostCommentLikeApiRequestBuilderFactory
{
	public DeletePostCommentLikeApiRequestBuilder Create(PostCommentLike postCommentLike)
	{
		return new(postCommentLike);
	}
}
