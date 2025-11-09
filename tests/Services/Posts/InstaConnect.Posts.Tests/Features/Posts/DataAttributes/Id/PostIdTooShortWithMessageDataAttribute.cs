using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostIdTooShortWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public PostIdTooShortWithMessageDataAttribute()
        : base(PostOutOfBoundsUtilities.IdTooShort, PostErrorMessages.GetIdTooShort(PostOutOfBoundsUtilities.IdTooShort))
    {
    }
}
