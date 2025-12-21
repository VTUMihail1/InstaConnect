namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostSortPropertyWithTitleTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<PostSortProperty, Post, string>
{
    public PostSortPropertyWithTitleTermDataAttribute()
        : base(PostSortProperty.ByTitle, p => p.Title)
    {
    }
}
