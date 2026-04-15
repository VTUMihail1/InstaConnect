namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortTerm.ForUser;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostsForUserSortTermTitleDataAttribute
    : SortEnumDataAttribute<PostsForUserSortTerm>
{
    public PostsForUserSortTermTitleDataAttribute()
        : base(PostsForUserSortTerm.ByTitle)
    {
    }
}
