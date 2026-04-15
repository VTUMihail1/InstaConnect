namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortTerm.ForUser;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostsForUserSortTermWithCreatedAtTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<PostsForUserSortTerm, Post, DateTimeOffset>
{
    public PostsForUserSortTermWithCreatedAtTermDataAttribute()
        : base(PostsForUserSortTerm.ByCreatedAt, p => p.CreatedAtUtc)
    {
    }
}
