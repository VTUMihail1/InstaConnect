namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentSortPropertyWithCreatedAtTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<PostCommentSortProperty, PostComment, DateTimeOffset>
{
    public PostCommentSortPropertyWithCreatedAtTermDataAttribute()
        : base(PostCommentSortProperty.ByCreatedAt, p => p.CreatedAtUtc)
    {
    }
}
