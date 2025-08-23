using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostContentTooLongWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public PostContentTooLongWithMessageDataAttribute()
        : base(PostOutOfBoundsUtilities.ContentTooLong, PostErrorMessages.GetContentTooLong(PostOutOfBoundsUtilities.ContentTooLong))
    {
    }
}

