using InstaConnect.Common.Extensions;
using InstaConnect.Common.Tests.Utilities.DataAttributes.String;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostContentTooShortWithMessageDataAttribute : OutOfBoundsStringWithMessageDataAttribute
{
    public PostContentTooShortWithMessageDataAttribute()
        : base(PostOutOfBoundUtilities.ContentTooShort, PostErrorMessages.GetContentTooShort(PostOutOfBoundUtilities.ContentTooShort))
    {
    }
}

