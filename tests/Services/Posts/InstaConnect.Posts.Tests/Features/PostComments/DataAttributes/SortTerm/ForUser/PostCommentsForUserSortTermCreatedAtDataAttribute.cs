namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortTerm.ForUser;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentsForUserSortTermCreatedAtDataAttribute
    : SortEnumDataAttribute<PostCommentsForUserSortTerm>
{
    public PostCommentsForUserSortTermCreatedAtDataAttribute()
        : base(PostCommentsForUserSortTerm.ByCreatedAt)
    {
    }
}
