namespace InstaConnect.Posts.Application.Tests.Features.PostLikes.Builders;

public class GetAllPostLikesQueryRequestBuilderFactory
{
	public GetAllPostLikesQueryRequestBuilder Create(PostLike postLike)
	{
		return new(postLike);
	}
}
