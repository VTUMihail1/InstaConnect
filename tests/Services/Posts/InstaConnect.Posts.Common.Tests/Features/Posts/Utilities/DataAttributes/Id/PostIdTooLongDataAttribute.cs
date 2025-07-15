using InstaConnect.Common.Tests.Utilities.DataAttributes.String;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostIdTooLongDataAttribute : OutOfBoundsStringWithMessageDataAttribute
{
    public PostIdTooLongDataAttribute()
        : base(PostOutOfBoundUtilities.IdTooLong, PostErrorMessages.GetIdTooLong(PostOutOfBoundUtilities.IdTooLong))
    {
    }
}

