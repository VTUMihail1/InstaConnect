namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortTerm.ForUser;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentsForUserSortTermWithCreatedAtTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<PostCommentsForUserSortTerm, PostComment, DateTimeOffset>
{
    public PostCommentsForUserSortTermWithCreatedAtTermDataAttribute()
        : base(PostCommentsForUserSortTerm.ByCreatedAt, p => p.CreatedAtUtc)
    {
    }
}
