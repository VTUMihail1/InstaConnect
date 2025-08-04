using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Length;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikeIdNotFoundDataAttribute : LengthStringDataAttribute
{
    public PostLikeIdNotFoundDataAttribute()
        : base(PostLikeTestValueUtilities.IdAverage)
    {
    }
}
