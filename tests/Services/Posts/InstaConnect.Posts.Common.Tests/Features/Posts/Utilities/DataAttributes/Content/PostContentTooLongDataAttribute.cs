using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostContentTooLongDataAttribute : LengthStringDataAttribute
{
    public PostContentTooLongDataAttribute()
        : base(PostTestValueUtilities.ContentTooLong)
    {
    }
}
