namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentsSortTermWithUserNameTermDataAttribute
	: SortEnumWithAscendingTermDataAttribute<PostCommentsSortTerm, PostComment, string>
{
	public PostCommentsSortTermWithUserNameTermDataAttribute()
		: base(PostCommentsSortTerm.ByUserName, p => p.User!.Name.Value)
	{
	}
}
