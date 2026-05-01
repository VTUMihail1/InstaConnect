namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostsSortTermWithCreatedAtTermDataAttribute
	: SortEnumWithAscendingTermDataAttribute<PostsSortTerm, Post, DateTimeOffset>
{
	public PostsSortTermWithCreatedAtTermDataAttribute()
		: base(PostsSortTerm.ByCreatedAt, p => p.CreatedAtUtc)
	{
	}
}
