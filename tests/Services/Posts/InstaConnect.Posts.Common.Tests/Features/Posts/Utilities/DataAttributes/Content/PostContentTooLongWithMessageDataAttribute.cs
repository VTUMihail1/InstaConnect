using InstaConnect.Common.Tests.Utilities.Types.Strings.Length;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostContentTooLongWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public PostContentTooLongWithMessageDataAttribute()
        : base(PostTestValueUtilities.ContentTooLong, PostErrorMessages.GetContentTooLong(PostTestValueUtilities.ContentTooLong))
    {
    }
}

