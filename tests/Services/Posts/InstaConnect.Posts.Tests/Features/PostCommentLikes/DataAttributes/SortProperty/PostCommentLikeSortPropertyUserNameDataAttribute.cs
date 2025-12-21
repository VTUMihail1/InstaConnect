namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikeSortPropertyUserNameDataAttribute
    : SortEnumDataAttribute<PostCommentLikeSortProperty>
{
    public PostCommentLikeSortPropertyUserNameDataAttribute()
        : base(PostCommentLikeSortProperty.ByUserName)
    {
    }
}
