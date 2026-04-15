namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortTerm.ForUser;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostsForUserSortTermWithTitleTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<PostsForUserSortTerm, Post, string>
{
    public PostsForUserSortTermWithTitleTermDataAttribute()
        : base(PostsForUserSortTerm.ByTitle, p => p.Title)
    {
    }
}
