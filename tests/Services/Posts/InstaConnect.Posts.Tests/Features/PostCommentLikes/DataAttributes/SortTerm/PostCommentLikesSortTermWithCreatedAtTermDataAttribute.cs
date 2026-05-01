namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikesSortTermWithCreatedAtTermDataAttribute
	: SortEnumWithAscendingTermDataAttribute<PostCommentLikesSortTerm, PostCommentLike, DateTimeOffset>
{
	public PostCommentLikesSortTermWithCreatedAtTermDataAttribute()
		: base(PostCommentLikesSortTerm.ByCreatedAt, p => p.CreatedAtUtc)
	{
	}
}
