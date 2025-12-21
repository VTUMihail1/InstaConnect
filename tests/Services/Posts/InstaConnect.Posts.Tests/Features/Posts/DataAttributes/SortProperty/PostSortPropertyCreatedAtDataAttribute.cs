namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostSortPropertyCreatedAtDataAttribute
    : SortEnumDataAttribute<PostSortProperty>
{
    public PostSortPropertyCreatedAtDataAttribute()
        : base(PostSortProperty.ByCreatedAt)
    {
    }
}
