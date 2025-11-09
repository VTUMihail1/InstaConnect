using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostContentTooLongWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public PostContentTooLongWithMessageDataAttribute()
        : base(PostOutOfBoundsUtilities.ContentTooLong, PostErrorMessages.GetContentTooLong(PostOutOfBoundsUtilities.ContentTooLong))
    {
    }
}

