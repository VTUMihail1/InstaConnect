using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Title;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostTitleTooShortWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public PostTitleTooShortWithMessageDataAttribute()
        : base(PostOutOfBoundsUtilities.TitleTooShort, PostErrorMessages.GetTitleTooShort(PostOutOfBoundsUtilities.TitleTooShort))
    {
    }
}
