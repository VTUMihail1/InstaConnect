namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentIdEmptyWithMessageDataAttribute : EmptyStringWithMessageDataAttribute
{
    public PostCommentIdEmptyWithMessageDataAttribute()
        : base(PostCommentErrorMessages.GetIdEmpty())
    {
    }
}

