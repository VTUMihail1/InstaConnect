using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Null;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostContentNullWithMessageDataAttribute : NullStringWithMessageDataAttribute
{
    public PostContentNullWithMessageDataAttribute()
        : base(PostErrorMessages.GetContentEmpty())
    {
    }
}

