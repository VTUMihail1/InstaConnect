using InstaConnect.Common.Tests.Utilities.DataAttributes;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostIdNullDataAttribute : NullDataAttribute
{
    public PostIdNullDataAttribute()
        : base(PostErrorMessages.GetIdEmpty())
    {
    }
}

