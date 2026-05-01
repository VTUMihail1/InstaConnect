namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikesSortTermWithCreatedAtTermDataAttribute
	: SortEnumWithAscendingTermDataAttribute<PostLikesSortTerm, PostLike, DateTimeOffset>
{
	public PostLikesSortTermWithCreatedAtTermDataAttribute()
		: base(PostLikesSortTerm.ByCreatedAt, p => p.CreatedAtUtc)
	{
	}
}
