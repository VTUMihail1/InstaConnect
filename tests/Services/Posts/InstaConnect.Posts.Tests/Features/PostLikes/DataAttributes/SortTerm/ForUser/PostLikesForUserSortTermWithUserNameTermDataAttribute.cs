namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.SortTerm.ForUser;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikesForUserSortTermWithUserNameTermDataAttribute
	: SortEnumWithAscendingTermDataAttribute<PostLikesForUserSortTerm, PostLike, string>
{
	public PostLikesForUserSortTermWithUserNameTermDataAttribute()
		: base(PostLikesForUserSortTerm.ByUserName, p => p.User!.Name.Value)
	{
	}
}
