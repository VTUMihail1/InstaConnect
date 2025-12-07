namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Title;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostTitleTooShortWithMessageDataAttribute : TooShortStringWithMessageDataAttribute
{
    public PostTitleTooShortWithMessageDataAttribute()
        : base(PostConfigurations.TitleMinLength)
    {
    }
}
