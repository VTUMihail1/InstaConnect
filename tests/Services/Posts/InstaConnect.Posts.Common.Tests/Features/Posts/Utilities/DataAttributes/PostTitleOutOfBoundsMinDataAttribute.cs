using InstaConnect.Common.Tests.Utilities.DataAttributes;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostTitleOutOfBoundsMinDataAttribute : OutOfBoundsMinStringDataAttribute
{
    public PostTitleOutOfBoundsMinDataAttribute()
        : base(PostConfigurations.TitleMinLength)
    {
    }
}
