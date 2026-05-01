namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortTerm.ForUser;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentsForUserSortTermWithUserNameTermDataAttribute
	: SortEnumWithAscendingTermDataAttribute<PostCommentsForUserSortTerm, PostComment, string>
{
	public PostCommentsForUserSortTermWithUserNameTermDataAttribute()
		: base(PostCommentsForUserSortTerm.ByUserName, p => p.User!.Name.Value)
	{
	}
}
