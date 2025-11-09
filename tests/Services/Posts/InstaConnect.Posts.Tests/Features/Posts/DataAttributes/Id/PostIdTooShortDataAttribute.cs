using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostIdTooShortDataAttribute : LengthStringDataAttribute
{
    public PostIdTooShortDataAttribute()
        : base(PostOutOfBoundsUtilities.IdTooShort)
    {
    }
}
