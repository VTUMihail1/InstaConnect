namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortTerm.ForUser;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikesForUserSortTermCreatedAtDataAttribute
    : SortEnumDataAttribute<PostCommentLikesForUserSortTerm>
{
    public PostCommentLikesForUserSortTermCreatedAtDataAttribute()
        : base(PostCommentLikesForUserSortTerm.ByCreatedAt)
    {
    }
}
