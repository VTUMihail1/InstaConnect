using InstaConnect.Common.Tests.Utilities.DataAttributes;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostIdTooShortDataAttribute : OutOfBoundsStringDataAttribute
{
    public PostIdTooShortDataAttribute()
        : base(PostOutOfBoundUtilities.IdTooShort, PostErrorMessages.GetIdTooShort(PostOutOfBoundUtilities.IdTooShort))
    {
    }
}

