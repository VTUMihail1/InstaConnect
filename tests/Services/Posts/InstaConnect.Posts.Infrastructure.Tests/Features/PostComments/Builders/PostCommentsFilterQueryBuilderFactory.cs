using InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Builders;

public class PostCommentsFilterQueryBuilderFactory
{
	public PostCommentsFilterQueryBuilder Create(PostComment postComment)
	{
		return new(postComment);
	}
}
