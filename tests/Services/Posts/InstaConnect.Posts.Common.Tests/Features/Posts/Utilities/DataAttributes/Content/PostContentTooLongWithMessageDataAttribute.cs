using InstaConnect.Common.Extensions;
using InstaConnect.Common.Tests.Utilities.DataAttributes.String;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostContentTooLongWithMessageDataAttribute : OutOfBoundsStringWithMessageDataAttribute
{
    public PostContentTooLongWithMessageDataAttribute()
        : base(PostOutOfBoundUtilities.ContentTooLong, PostErrorMessages.GetContentTooLong(PostOutOfBoundUtilities.ContentTooLong))
    {
    }
}

