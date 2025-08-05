using InstaConnect.Common.Extensions;
using InstaConnect.PostComments.Common.Features.PostComments.Utilities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;

public static class PostCommentTestValueUtilities
{
    public static readonly int IdAverage = IntOperations.Average(PostCommentConfigurations.IdMaxLength, PostCommentConfigurations.IdMinLength);
    public static readonly int IdTooShort = IntOperations.Decrement(PostCommentConfigurations.IdMinLength);
    public static readonly int IdTooLong = IntOperations.Increment(PostCommentConfigurations.IdMaxLength);

    public static readonly int ContentTooShort = IntOperations.Decrement(PostCommentConfigurations.ContentMinLength);
    public static readonly int ContentTooLong = IntOperations.Increment(PostCommentConfigurations.ContentMaxLength);

    public static readonly int PageTooSmall = IntOperations.Decrement(PostCommentConfigurations.PageMinValue);
    public static readonly int PageTooLarge = IntOperations.Increment(PostCommentConfigurations.PageMaxValue);

    public static readonly int PageSizeTooSmall = IntOperations.Decrement(PostCommentConfigurations.PageSizeMinValue);
    public static readonly int PageSizeTooLarge = IntOperations.Increment(PostCommentConfigurations.PageSizeMaxValue);
}
