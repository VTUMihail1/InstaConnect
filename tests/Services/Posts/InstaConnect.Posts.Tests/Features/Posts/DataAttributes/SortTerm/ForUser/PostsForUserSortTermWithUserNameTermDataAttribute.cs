namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortTerm.ForUser;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostsForUserSortTermWithUserNameTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<PostsForUserSortTerm, Post, string>
{
    public PostsForUserSortTermWithUserNameTermDataAttribute()
        : base(PostsForUserSortTerm.ByUserName, p => p.User!.Name.Value)
    {
    }
}
