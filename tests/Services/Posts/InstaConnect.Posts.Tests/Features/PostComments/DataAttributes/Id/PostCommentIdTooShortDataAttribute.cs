namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentIdTooShortDataAttribute : TooShortStringDataAttribute
{
    public PostCommentIdTooShortDataAttribute()
        : base(PostCommentConfigurations.IdMinLength)
    {
    }
}
