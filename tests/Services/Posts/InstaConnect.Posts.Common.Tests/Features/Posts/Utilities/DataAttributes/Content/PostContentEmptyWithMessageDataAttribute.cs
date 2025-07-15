using InstaConnect.Common.Tests.Utilities.DataAttributes.String;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostContentEmptyWithMessageDataAttribute : EmptyStringWithMessageDataAttribute
{
    public PostContentEmptyWithMessageDataAttribute()
        : base(PostErrorMessages.GetContentEmpty())
    {
    }
}

