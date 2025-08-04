using InstaConnect.Common.Tests.Utilities.Types.Strings.Length;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikeIdTooLongDataAttribute : LengthStringDataAttribute
{
    public PostLikeIdTooLongDataAttribute()
        : base(PostLikeTestValueUtilities.IdTooLong)
    {
    }
}
