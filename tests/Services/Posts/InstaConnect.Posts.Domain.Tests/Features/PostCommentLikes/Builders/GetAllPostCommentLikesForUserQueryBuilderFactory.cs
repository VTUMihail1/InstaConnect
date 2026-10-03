namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesForUserQueryBuilderFactory
{
	public GetAllPostCommentLikesForUserQueryBuilder Create(PostCommentLike postCommentLike)
	{
		return new(postCommentLike);
	}
}
