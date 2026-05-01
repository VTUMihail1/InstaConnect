namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesForUserApiRequestBuilderFactory
{
	public GetAllPostCommentLikesForUserApiRequestBuilder Create(PostCommentLike postCommentLike)
	{
		return new(postCommentLike);
	}
}
