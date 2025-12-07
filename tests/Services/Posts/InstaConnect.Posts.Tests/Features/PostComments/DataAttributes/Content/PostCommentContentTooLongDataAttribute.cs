namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentContentTooLongDataAttribute : TooLongStringDataAttribute
{
    public PostCommentContentTooLongDataAttribute()
        : base(PostCommentConfigurations.ContentMaxLength)
    {
    }
}
