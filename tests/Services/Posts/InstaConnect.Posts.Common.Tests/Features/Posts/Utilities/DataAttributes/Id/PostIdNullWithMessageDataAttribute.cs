using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Null;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostIdNullWithMessageDataAttribute : NullStringWithMessageDataAttribute
{
    public PostIdNullWithMessageDataAttribute()
        : base(PostErrorMessages.GetIdEmpty())
    {
    }
}

