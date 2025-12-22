namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentSortPropertyWithUserNameTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<PostCommentSortProperty, PostComment, string>
{
    public PostCommentSortPropertyWithUserNameTermDataAttribute()
        : base(PostCommentSortProperty.ByUserName, p => p.User!.Name.Value)
    {
    }
}
