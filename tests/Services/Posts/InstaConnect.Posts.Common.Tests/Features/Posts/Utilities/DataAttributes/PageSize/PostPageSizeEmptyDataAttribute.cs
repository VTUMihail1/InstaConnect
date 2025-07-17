using InstaConnect.Common.Tests.Utilities.Types.Ints.Empty;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageSizeEmptyDataAttribute : EmptyIntWithMessageDataAttribute
{
    public PostPageSizeEmptyDataAttribute()
        : base(PostErrorMessages.GetPageSizeEmpty())
    {
    }
}

