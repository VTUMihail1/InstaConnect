namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Title;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostTitleTooLongDataAttribute : TooLongStringDataAttribute
{
    public PostTitleTooLongDataAttribute()
        : base(PostConfigurations.TitleMaxLength)
    {
    }
}
