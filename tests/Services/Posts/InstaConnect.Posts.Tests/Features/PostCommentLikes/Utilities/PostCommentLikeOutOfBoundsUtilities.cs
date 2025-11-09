namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeOutOfBoundsUtilities
{
    public static readonly int PageTooSmall = IntOperations.Decrement(PostCommentLikeConfigurations.PageMinValue);
    public static readonly int PageTooLarge = IntOperations.Increment(PostCommentLikeConfigurations.PageMaxValue);

    public static readonly int PageSizeTooSmall = IntOperations.Decrement(PostCommentLikeConfigurations.PageSizeMinValue);
    public static readonly int PageSizeTooLarge = IntOperations.Increment(PostCommentLikeConfigurations.PageSizeMaxValue);
}
