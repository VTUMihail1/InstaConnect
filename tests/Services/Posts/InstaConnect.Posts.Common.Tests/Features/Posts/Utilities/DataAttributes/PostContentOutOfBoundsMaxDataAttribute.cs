using InstaConnect.Common.Extensions;
using InstaConnect.Common.Tests.Utilities.DataAttributes;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostContentOutOfBoundsMaxDataAttribute : OutOfBoundsStringDataAttribute
{
    public override int Length => PostConfigurations.ContentMaxLength.Increment();

    public override string Message => PostErrorMessages.GetContentTooLong();
}

