using InstaConnect.Common.Tests.Utilities.DataAttributes;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Title;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostTitleNullDataAttribute : NullWithMessageDataAttribute
{
    public PostTitleNullDataAttribute()
        : base(PostErrorMessages.GetTitleEmpty())
    {
    }
}

