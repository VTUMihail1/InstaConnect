using InstaConnect.Common.Tests.Utilities.Types.Strings.Empty;
using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikeIdEmptyWithMessageDataAttribute : EmptyStringWithMessageDataAttribute
{
    public PostLikeIdEmptyWithMessageDataAttribute()
        : base(PostLikeErrorMessages.GetIdEmpty())
    {
    }
}

