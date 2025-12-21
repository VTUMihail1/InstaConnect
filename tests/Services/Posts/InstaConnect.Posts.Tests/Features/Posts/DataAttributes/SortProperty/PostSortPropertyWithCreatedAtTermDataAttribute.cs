namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostSortPropertyWithCreatedAtTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<PostSortProperty, Post, DateTimeOffset>
{
    public PostSortPropertyWithCreatedAtTermDataAttribute()
        : base(PostSortProperty.ByCreatedAt, p => p.CreatedAtUtc)
    {
    }
}
