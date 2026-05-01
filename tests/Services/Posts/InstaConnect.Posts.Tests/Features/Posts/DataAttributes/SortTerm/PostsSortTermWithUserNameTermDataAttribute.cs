namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostsSortTermWithUserNameTermDataAttribute
	: SortEnumWithAscendingTermDataAttribute<PostsSortTerm, Post, string>
{
	public PostsSortTermWithUserNameTermDataAttribute()
		: base(PostsSortTerm.ByUserName, p => p.User!.Name.Value)
	{
	}
}
