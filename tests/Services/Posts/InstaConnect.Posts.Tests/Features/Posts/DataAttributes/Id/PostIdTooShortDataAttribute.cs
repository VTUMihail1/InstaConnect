namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostIdTooShortDataAttribute : TooShortStringDataAttribute
{
    public PostIdTooShortDataAttribute()
        : base(PostConfigurations.IdMinLength)
    {
    }
}
