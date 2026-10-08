using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Builders;

public class PostLikesFilterQueryBuilderFactory
{
	public PostLikesFilterQueryBuilder Create(PostLike postLike)
	{
		return new(postLike);
	}
}
