namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.SortTerm.ForUser;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikesForUserSortTermCreatedAtDataAttribute
	: SortEnumDataAttribute<PostLikesForUserSortTerm>
{
	public PostLikesForUserSortTermCreatedAtDataAttribute()
		: base(PostLikesForUserSortTerm.ByCreatedAt)
	{
	}
}
