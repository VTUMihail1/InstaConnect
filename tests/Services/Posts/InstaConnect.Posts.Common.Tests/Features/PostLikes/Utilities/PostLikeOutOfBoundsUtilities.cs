using InstaConnect.Common.Extensions;
using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;

public static class PostLikeOutOfBoundsUtilities
{
    public static readonly int IdTooShort = IntOperations.Decrement(PostLikeConfigurations.IdMinLength);
    public static readonly int IdTooLong = IntOperations.Increment(PostLikeConfigurations.IdMaxLength);

    public static readonly int PageTooSmall = IntOperations.Decrement(PostLikeConfigurations.PageMinValue);
    public static readonly int PageTooLarge = IntOperations.Increment(PostLikeConfigurations.PageMaxValue);

    public static readonly int PageSizeTooSmall = IntOperations.Decrement(PostLikeConfigurations.PageSizeMinValue);
    public static readonly int PageSizeTooLarge = IntOperations.Increment(PostLikeConfigurations.PageSizeMaxValue);
}
