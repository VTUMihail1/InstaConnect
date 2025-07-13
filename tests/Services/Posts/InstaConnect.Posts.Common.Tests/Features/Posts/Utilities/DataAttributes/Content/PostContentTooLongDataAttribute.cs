using InstaConnect.Common.Extensions;
using InstaConnect.Common.Tests.Utilities.DataAttributes;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostContentTooLongDataAttribute : OutOfBoundsStringDataAttribute
{
    public PostContentTooLongDataAttribute()
        : base(PostOutOfBoundUtilities.ContentTooLong, PostErrorMessages.GetContentTooLong(PostOutOfBoundUtilities.ContentTooLong))
    {
    }
}

