namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Builders;

public class DeletePostLikeCommandBuilderFactory
{
	public DeletePostLikeCommandBuilder Create(PostLike postLike)
	{
		return new(postLike);
	}
}
