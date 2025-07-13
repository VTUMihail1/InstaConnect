using InstaConnect.Common.Tests.Utilities.DataAttributes;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostContentEmptyDataAttribute : EmptyStringDataAttribute
{
    public PostContentEmptyDataAttribute()
        : base(PostErrorMessages.GetContentEmpty())
    {
    }
}

