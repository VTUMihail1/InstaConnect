namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostContentTooLongDataAttribute : TooLongStringDataAttribute
{
    public PostContentTooLongDataAttribute()
        : base(PostConfigurations.ContentMaxLength)
    {
    }
}
