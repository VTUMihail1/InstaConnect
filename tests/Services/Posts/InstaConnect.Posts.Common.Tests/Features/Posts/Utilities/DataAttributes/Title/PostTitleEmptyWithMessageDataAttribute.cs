using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Empty;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Title;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostTitleEmptyWithMessageDataAttribute : EmptyStringWithMessageDataAttribute
{
    public PostTitleEmptyWithMessageDataAttribute()
        : base(PostErrorMessages.GetTitleEmpty())
    {
    }
}
