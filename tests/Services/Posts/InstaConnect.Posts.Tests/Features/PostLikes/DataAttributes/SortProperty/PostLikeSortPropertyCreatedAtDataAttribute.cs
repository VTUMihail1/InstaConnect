namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikeSortPropertyCreatedAtDataAttribute
    : SortEnumDataAttribute<PostLikeSortProperty>
{
    public PostLikeSortPropertyCreatedAtDataAttribute()
        : base(PostLikeSortProperty.ByCreatedAt)
    {
    }
}
