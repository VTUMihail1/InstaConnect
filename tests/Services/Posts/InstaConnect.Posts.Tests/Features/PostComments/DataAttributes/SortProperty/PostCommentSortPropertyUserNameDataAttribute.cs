namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentSortPropertyUserNameDataAttribute
    : SortEnumDataAttribute<PostCommentSortProperty>
{
    public PostCommentSortPropertyUserNameDataAttribute()
        : base(PostCommentSortProperty.ByUserName)
    {
    }
}
