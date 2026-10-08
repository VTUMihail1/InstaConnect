namespace InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Builders;

public class GetAllPostCommentLikesQueryBuilderFactory
{
	public GetAllPostCommentLikesQueryBuilder Create(PostCommentLike postCommentLike)
	{
		return new(postCommentLike);
	}
}
