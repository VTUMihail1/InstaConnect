using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostContentTooShortWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public PostContentTooShortWithMessageDataAttribute()
        : base(PostOutOfBoundsUtilities.ContentTooShort, PostErrorMessages.GetContentTooShort(PostOutOfBoundsUtilities.ContentTooShort))
    {
    }
}

