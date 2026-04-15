namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikesSortTermCreatedAtDataAttribute
    : SortEnumDataAttribute<PostCommentLikesSortTerm>
{
    public PostCommentLikesSortTermCreatedAtDataAttribute()
        : base(PostCommentLikesSortTerm.ByCreatedAt)
    {
    }
}
