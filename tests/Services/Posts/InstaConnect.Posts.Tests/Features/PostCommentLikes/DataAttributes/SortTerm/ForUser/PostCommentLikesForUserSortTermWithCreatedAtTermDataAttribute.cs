namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortTerm.ForUser;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikesForUserSortTermWithCreatedAtTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<PostCommentLikesForUserSortTerm, PostCommentLike, DateTimeOffset>
{
    public PostCommentLikesForUserSortTermWithCreatedAtTermDataAttribute()
        : base(PostCommentLikesForUserSortTerm.ByCreatedAt, p => p.CreatedAtUtc)
    {
    }
}
