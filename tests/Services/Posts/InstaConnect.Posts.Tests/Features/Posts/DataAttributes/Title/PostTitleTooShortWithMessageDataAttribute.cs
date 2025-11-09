using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Title;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostTitleTooShortWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostTitleTooShortWithMessageDataAttribute()
        : base(PostOutOfBoundsUtilities.TitleTooShort, PostErrorMessages.GetTitleTooShort(PostOutOfBoundsUtilities.TitleTooShort))
    {
    }
}
