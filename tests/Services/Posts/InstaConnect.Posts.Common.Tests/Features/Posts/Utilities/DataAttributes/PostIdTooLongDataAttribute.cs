using InstaConnect.Common.Tests.Utilities.DataAttributes;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostIdTooLongDataAttribute : OutOfBoundsStringDataAttribute
{
    public PostIdTooLongDataAttribute()
        : base(PostOutOfBoundUtilities.IdTooLong, PostErrorMessages.GetIdTooLong(PostOutOfBoundUtilities.IdTooLong))
    {
    }
}

