namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Builders;

public class DeletePostCommentLikeCommandBuilderFactory
{
	public DeletePostCommentLikeCommandBuilder Create(PostCommentLike postCommentLike)
	{
		return new(postCommentLike);
	}
}
