using InstaConnect.Common.Extensions;
using InstaConnect.PostCommentLikes.Common.Features.PostCommentLikes.Utilities;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeTestValueUtilities
{
    public static readonly int IdAverage = IntOperations.Average(PostCommentLikeConfigurations.IdMaxLength, PostCommentLikeConfigurations.IdMinLength);
    public static readonly int IdTooShort = IntOperations.Decrement(PostCommentLikeConfigurations.IdMinLength);
    public static readonly int IdTooLong = IntOperations.Increment(PostCommentLikeConfigurations.IdMaxLength);

    public static readonly int PageTooSmall = IntOperations.Decrement(PostCommentLikeConfigurations.PageMinValue);
    public static readonly int PageTooLarge = IntOperations.Increment(PostCommentLikeConfigurations.PageMaxValue);

    public static readonly int PageSizeTooSmall = IntOperations.Decrement(PostCommentLikeConfigurations.PageSizeMinValue);
    public static readonly int PageSizeTooLarge = IntOperations.Increment(PostCommentLikeConfigurations.PageSizeMaxValue);
}
