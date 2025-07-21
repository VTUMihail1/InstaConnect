using InstaConnect.Common.Tests.Utilities.Types.Strings.Average;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Length;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostIdTooLongWithMessageDataAttribute : LengthStringWithMessageDataAttribute
{
    public PostIdTooLongWithMessageDataAttribute()
        : base(PostTestValueUtilities.IdTooLong, PostErrorMessages.GetIdTooLong(PostTestValueUtilities.IdTooLong))
    {
    }
}
