using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.Posts.Builders;

public class PostIdBuilderFactory
{
	public PostIdBuilder Create(PostId id)
	{
		return new(id);
	}
}
