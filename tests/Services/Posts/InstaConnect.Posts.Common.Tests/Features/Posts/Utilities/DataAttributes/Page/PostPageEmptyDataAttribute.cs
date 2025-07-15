using InstaConnect.Common.Tests.Utilities.DataAttributes.Int;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageEmptyDataAttribute : EmptyIntWithMessageDataAttribute
{
    public PostPageEmptyDataAttribute()
        : base(PostErrorMessages.GetPageEmpty())
    {
    }
}

