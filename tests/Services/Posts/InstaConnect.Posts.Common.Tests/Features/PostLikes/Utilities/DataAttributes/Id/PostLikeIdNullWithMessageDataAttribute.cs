using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Null;
using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikeIdNullWithMessageDataAttribute : NullStringWithMessageDataAttribute
{
    public PostLikeIdNullWithMessageDataAttribute()
        : base(PostLikeErrorMessages.GetIdEmpty())
    {
    }
}

