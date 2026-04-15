namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostContentTooShortDataAttribute : TooShortStringDataAttribute
{
    public PostContentTooShortDataAttribute()
        : base(PostConfigurations.ContentMinLength)
    {
    }
}
