namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;

public class DeletePostLikeCommandRequestBuilderFactory
{
	public DeletePostLikeCommandRequestBuilder Create(PostLike postLike)
	{
		return new(postLike);
	}
}
