namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortTerm;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentsSortTermCreatedAtDataAttribute
    : SortEnumDataAttribute<PostCommentsSortTerm>
{
    public PostCommentsSortTermCreatedAtDataAttribute()
        : base(PostCommentsSortTerm.ByCreatedAt)
    {
    }
}
