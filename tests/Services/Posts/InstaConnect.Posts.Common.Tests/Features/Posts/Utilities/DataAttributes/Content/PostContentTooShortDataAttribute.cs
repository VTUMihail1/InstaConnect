using InstaConnect.Common.Tests.Utilities.Types.Strings.Length;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostContentTooShortDataAttribute : LengthStringDataAttribute
{
    public PostContentTooShortDataAttribute()
        : base(PostTestValueUtilities.ContentTooShort)
    {
    }
}
