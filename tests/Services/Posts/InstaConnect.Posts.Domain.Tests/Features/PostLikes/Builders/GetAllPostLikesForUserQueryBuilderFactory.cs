namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Builders;

public class GetAllPostLikesForUserQueryBuilderFactory
{
	public GetAllPostLikesForUserQueryBuilder Create(PostLike postLike)
	{
		return new(postLike);
	}
}
