namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Builders;

public class AddPostCommentLikeCommandRequestBuilderFactory
{
	public AddPostCommentLikeCommandRequestBuilder Create(PostComment postComment, User user)
	{
		return new(postComment, user);
	}
}
