using InstaConnect.Common.Tests.Utilities.Types.Ints.Value;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Title;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostTitleTooLongWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostTitleTooLongWithMessageDataAttribute()
        : base(PostTestValueUtilities.TitleTooLong, PostErrorMessages.GetTitleTooLong(PostTestValueUtilities.TitleTooLong))
    {
    }
}
