using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Builders;

public class PostLikeIdBuilderFactory
{
	public PostLikeIdBuilder Create(PostLikeId id)
	{
		return new(id);
	}
}
