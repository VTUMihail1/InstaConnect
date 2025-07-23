using InstaConnect.Common.Tests.Utilities.Types.Ints.Value;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageTooSmallDataAttribute : ValueIntDataAttribute
{
    public PostPageTooSmallDataAttribute()
        : base(PostTestValueUtilities.PageTooSmall)
    {
    }
}

