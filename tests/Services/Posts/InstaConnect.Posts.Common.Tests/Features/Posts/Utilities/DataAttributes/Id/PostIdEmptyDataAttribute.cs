using InstaConnect.Common.Tests.Utilities.DataAttributes.String;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostIdEmptyDataAttribute : EmptyStringWithMessageDataAttribute
{
    public PostIdEmptyDataAttribute()
        : base(PostErrorMessages.GetIdEmpty())
    {
    }
}

