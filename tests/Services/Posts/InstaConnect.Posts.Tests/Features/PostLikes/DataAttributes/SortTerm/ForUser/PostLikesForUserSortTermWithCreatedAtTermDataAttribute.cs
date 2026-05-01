namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.SortTerm.ForUser;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikesForUserSortTermWithCreatedAtTermDataAttribute
	: SortEnumWithAscendingTermDataAttribute<PostLikesForUserSortTerm, PostLike, DateTimeOffset>
{
	public PostLikesForUserSortTermWithCreatedAtTermDataAttribute()
		: base(PostLikesForUserSortTerm.ByCreatedAt, p => p.CreatedAtUtc)
	{
	}
}
