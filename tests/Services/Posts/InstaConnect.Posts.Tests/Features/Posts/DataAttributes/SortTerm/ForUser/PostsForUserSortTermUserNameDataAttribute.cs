namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortTerm.ForUser;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostsForUserSortTermUserNameDataAttribute
    : SortEnumDataAttribute<PostsForUserSortTerm>
{
    public PostsForUserSortTermUserNameDataAttribute()
        : base(PostsForUserSortTerm.ByUserName)
    {
    }
}
