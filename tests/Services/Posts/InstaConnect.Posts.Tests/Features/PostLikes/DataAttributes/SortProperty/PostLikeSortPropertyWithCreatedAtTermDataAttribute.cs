namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikeSortPropertyWithCreatedAtTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<PostLikeSortProperty, PostLike, DateTimeOffset>
{
    public PostLikeSortPropertyWithCreatedAtTermDataAttribute()
        : base(PostLikeSortProperty.ByCreatedAt, p => p.CreatedAtUtc)
    {
    }
}
