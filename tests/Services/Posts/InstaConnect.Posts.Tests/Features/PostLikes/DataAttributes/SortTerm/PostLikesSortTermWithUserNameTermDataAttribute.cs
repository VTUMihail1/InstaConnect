namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikesSortTermWithUserNameTermDataAttribute
	: SortEnumWithAscendingTermDataAttribute<PostLikesSortTerm, PostLike, string>
{
	public PostLikesSortTermWithUserNameTermDataAttribute()
		: base(PostLikesSortTerm.ByUserName, p => p.User!.Name.Value)
	{
	}
}
