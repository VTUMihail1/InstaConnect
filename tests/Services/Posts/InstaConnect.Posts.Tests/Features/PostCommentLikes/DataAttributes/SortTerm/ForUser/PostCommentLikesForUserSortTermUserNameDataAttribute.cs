namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortTerm.ForUser;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikesForUserSortTermUserNameDataAttribute
    : SortEnumDataAttribute<PostCommentLikesForUserSortTerm>
{
    public PostCommentLikesForUserSortTermUserNameDataAttribute()
        : base(PostCommentLikesForUserSortTerm.ByUserName)
    {
    }
}
