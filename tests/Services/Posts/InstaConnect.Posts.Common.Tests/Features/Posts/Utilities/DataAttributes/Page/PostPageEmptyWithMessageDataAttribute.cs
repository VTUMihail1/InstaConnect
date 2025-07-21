using InstaConnect.Common.Tests.Utilities.Types.Ints.Empty;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageEmptyWithMessageDataAttribute : EmptyIntWithMessageDataAttribute
{
    public PostPageEmptyWithMessageDataAttribute()
        : base(PostErrorMessages.GetPageEmpty())
    {
    }
}
