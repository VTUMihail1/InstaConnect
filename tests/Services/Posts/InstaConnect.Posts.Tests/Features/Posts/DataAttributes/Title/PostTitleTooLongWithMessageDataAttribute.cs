using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Title;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostTitleTooLongWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostTitleTooLongWithMessageDataAttribute()
        : base(PostOutOfBoundsUtilities.TitleTooLong, PostErrorMessages.GetTitleTooLong(PostOutOfBoundsUtilities.TitleTooLong))
    {
    }
}
