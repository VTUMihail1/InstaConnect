namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostSortPropertyTitleDataAttribute
    : SortEnumDataAttribute<PostSortProperty>
{
    public PostSortPropertyTitleDataAttribute()
        : base(PostSortProperty.ByTitle)
    {
    }
}
