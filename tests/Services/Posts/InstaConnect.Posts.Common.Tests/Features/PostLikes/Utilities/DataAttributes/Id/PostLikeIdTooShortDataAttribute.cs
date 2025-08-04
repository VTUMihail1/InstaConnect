using InstaConnect.Common.Tests.Utilities.Types.Strings.Length;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikeIdTooShortDataAttribute : LengthStringDataAttribute
{
    public PostLikeIdTooShortDataAttribute()
        : base(PostLikeTestValueUtilities.IdTooShort)
    {
    }
}
