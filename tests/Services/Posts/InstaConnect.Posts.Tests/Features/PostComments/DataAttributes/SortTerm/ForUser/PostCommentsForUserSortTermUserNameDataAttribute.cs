namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortTerm.ForUser;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentsForUserSortTermUserNameDataAttribute
    : SortEnumDataAttribute<PostCommentsForUserSortTerm>
{
    public PostCommentsForUserSortTermUserNameDataAttribute()
        : base(PostCommentsForUserSortTerm.ByUserName)
    {
    }
}
