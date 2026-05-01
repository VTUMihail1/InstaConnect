namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikesSortTermUserNameDataAttribute
	: SortEnumDataAttribute<PostCommentLikesSortTerm>
{
	public PostCommentLikesSortTermUserNameDataAttribute()
		: base(PostCommentLikesSortTerm.ByUserName)
	{
	}
}
