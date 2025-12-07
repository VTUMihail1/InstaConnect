namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentContentTooShortWithMessageDataAttribute : TooShortStringWithMessageDataAttribute
{
    public PostCommentContentTooShortWithMessageDataAttribute()
        : base(PostCommentConfigurations.ContentMinLength)
    {
    }
}

