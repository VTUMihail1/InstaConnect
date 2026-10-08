namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Builders;

public class GetPostLikeByIdQueryBuilderFactory
{
	public GetPostLikeByIdQueryBuilder Create(PostLike postLike)
	{
		return new(postLike);
	}
}
