namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikeSortPropertyCreatedAtDataAttribute
    : SortEnumDataAttribute<PostCommentLikeSortProperty>
{
    public PostCommentLikeSortPropertyCreatedAtDataAttribute()
        : base(PostCommentLikeSortProperty.ByCreatedAt)
    {
    }
}
