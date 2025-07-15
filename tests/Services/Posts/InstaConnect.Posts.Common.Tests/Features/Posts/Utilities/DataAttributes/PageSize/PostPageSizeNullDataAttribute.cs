using InstaConnect.Common.Tests.Utilities.DataAttributes;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageSizeNullDataAttribute : NullWithMessageDataAttribute
{
    public PostPageSizeNullDataAttribute()
        : base(PostErrorMessages.GetPageSizeEmpty())
    {
    }
}

