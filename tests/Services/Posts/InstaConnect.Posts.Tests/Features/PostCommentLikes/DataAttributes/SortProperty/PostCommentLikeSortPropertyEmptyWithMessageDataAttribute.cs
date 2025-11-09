namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikeSortPropertyEmptyWithMessageDataAttribute : EmptyEnumWithMessageDataAttribute<PostCommentLikeSortProperty>
{
    public PostCommentLikeSortPropertyEmptyWithMessageDataAttribute()
        : base(PostCommentLikeErrorMessages.GetSortPropertyEmpty())
    {
    }
}
