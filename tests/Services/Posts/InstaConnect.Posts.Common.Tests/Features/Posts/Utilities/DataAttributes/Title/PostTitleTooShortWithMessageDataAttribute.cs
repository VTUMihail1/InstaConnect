using InstaConnect.Common.Tests.Utilities.Types.Ints.Value;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Title;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostTitleTooShortWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostTitleTooShortWithMessageDataAttribute()
        : base(PostTestValueUtilities.TitleTooShort, PostErrorMessages.GetTitleTooShort(PostTestValueUtilities.TitleTooShort))
    {
    }
}
