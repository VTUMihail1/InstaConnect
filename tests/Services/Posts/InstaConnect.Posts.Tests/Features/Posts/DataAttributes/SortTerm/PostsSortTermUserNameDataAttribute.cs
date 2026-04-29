namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostsSortTermUserNameDataAttribute
	: SortEnumDataAttribute<PostsSortTerm>
{
	public PostsSortTermUserNameDataAttribute()
		: base(PostsSortTerm.ByUserName)
	{
	}
}
