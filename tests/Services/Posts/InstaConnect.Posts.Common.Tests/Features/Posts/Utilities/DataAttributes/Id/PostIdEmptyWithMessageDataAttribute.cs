using InstaConnect.Common.Tests.Utilities.Types.Strings.Empty;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostIdEmptyWithMessageDataAttribute : EmptyStringWithMessageDataAttribute
{
    public PostIdEmptyWithMessageDataAttribute()
        : base(PostErrorMessages.GetIdEmpty())
    {
    }
}

