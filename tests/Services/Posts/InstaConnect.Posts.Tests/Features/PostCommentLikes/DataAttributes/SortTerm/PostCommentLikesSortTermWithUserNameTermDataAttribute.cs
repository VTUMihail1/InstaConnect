namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikesSortTermWithUserNameTermDataAttribute
	: SortEnumWithAscendingTermDataAttribute<PostCommentLikesSortTerm, PostCommentLike, string>
{
	public PostCommentLikesSortTermWithUserNameTermDataAttribute()
		: base(PostCommentLikesSortTerm.ByUserName, p => p.User!.Name.Value)
	{
	}
}
