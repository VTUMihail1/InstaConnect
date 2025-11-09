using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostIdTooLongWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public PostIdTooLongWithMessageDataAttribute()
        : base(PostOutOfBoundsUtilities.IdTooLong, PostErrorMessages.GetIdTooLong(PostOutOfBoundsUtilities.IdTooLong))
    {
    }
}
