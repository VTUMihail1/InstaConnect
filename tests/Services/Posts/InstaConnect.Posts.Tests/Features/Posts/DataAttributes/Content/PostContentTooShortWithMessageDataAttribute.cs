using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostContentTooShortWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public PostContentTooShortWithMessageDataAttribute()
        : base(PostOutOfBoundsUtilities.ContentTooShort, PostErrorMessages.GetContentTooShort(PostOutOfBoundsUtilities.ContentTooShort))
    {
    }
}

