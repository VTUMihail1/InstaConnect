namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.SortTerm.ForUser;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikesForUserSortTermUserNameDataAttribute
    : SortEnumDataAttribute<PostLikesForUserSortTerm>
{
    public PostLikesForUserSortTermUserNameDataAttribute()
        : base(PostLikesForUserSortTerm.ByUserName)
    {
    }
}
