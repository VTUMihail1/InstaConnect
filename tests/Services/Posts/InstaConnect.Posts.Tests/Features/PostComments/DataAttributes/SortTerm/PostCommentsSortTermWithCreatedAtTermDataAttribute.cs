namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentsSortTermWithCreatedAtTermDataAttribute
	: SortEnumWithAscendingTermDataAttribute<PostCommentsSortTerm, PostComment, DateTimeOffset>
{
	public PostCommentsSortTermWithCreatedAtTermDataAttribute()
		: base(PostCommentsSortTerm.ByCreatedAt, p => p.CreatedAtUtc)
	{
	}
}
