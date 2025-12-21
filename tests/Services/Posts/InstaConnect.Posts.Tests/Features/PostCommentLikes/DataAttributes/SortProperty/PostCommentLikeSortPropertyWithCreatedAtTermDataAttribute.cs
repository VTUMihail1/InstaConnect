namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikeSortPropertyWithCreatedAtTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<PostCommentLikeSortProperty, PostCommentLike, DateTimeOffset>
{
    public PostCommentLikeSortPropertyWithCreatedAtTermDataAttribute()
        : base(PostCommentLikeSortProperty.ByCreatedAt, p => p.CreatedAtUtc)
    {
    }
}
