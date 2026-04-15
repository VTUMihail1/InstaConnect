namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortTerm.ForUser;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikesForUserSortTermWithUserNameTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<PostCommentLikesForUserSortTerm, PostCommentLike, string>
{
    public PostCommentLikesForUserSortTermWithUserNameTermDataAttribute()
        : base(PostCommentLikesForUserSortTerm.ByUserName, p => p.User!.Name.Value)
    {
    }
}
