using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Value;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Title;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostTitleTooLongWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostTitleTooLongWithMessageDataAttribute()
        : base(PostOutOfBoundsUtilities.TitleTooLong, PostErrorMessages.GetTitleTooLong(PostOutOfBoundsUtilities.TitleTooLong))
    {
    }
}
