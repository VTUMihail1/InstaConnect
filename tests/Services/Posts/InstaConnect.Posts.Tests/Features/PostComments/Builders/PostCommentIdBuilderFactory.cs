using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;

namespace InstaConnect.Posts.Tests.Features.PostComments.Builders;

public class PostCommentIdBuilderFactory
{
	public PostCommentIdBuilder Create(PostCommentId id)
	{
		return new(id);
	}
}
