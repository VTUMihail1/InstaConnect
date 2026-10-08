namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Builders;

public class GetAllPostLikesQueryBuilderFactory
{
	public GetAllPostLikesQueryBuilder Create(PostLike postLike)
	{
		return new(postLike);
	}
}
