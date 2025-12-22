namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikeSortPropertyWithUserNameTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<PostCommentLikeSortProperty, PostCommentLike, string>
{
    public PostCommentLikeSortPropertyWithUserNameTermDataAttribute()
        : base(PostCommentLikeSortProperty.ByUserName, p => p.User!.Name.Value)
    {
    }
}
