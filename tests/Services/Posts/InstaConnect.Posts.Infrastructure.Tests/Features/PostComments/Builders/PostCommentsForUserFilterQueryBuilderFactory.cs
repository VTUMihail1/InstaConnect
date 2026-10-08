using InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Builders;

public class PostCommentsForUserFilterQueryBuilderFactory
{
	public PostCommentsForUserFilterQueryBuilder Create(PostComment postComment)
	{
		return new(postComment);
	}
}
