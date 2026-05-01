namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostsSortTermTitleDataAttribute
	: SortEnumDataAttribute<PostsSortTerm>
{
	public PostsSortTermTitleDataAttribute()
		: base(PostsSortTerm.ByTitle)
	{
	}
}
