namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Builders;

public class GetAllPostLikesForUserApiRequestBuilderFactory
{
	public GetAllPostLikesForUserApiRequestBuilder Create(PostLike postLike)
	{
		return new(postLike);
	}
}
