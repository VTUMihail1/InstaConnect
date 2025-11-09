namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public static class PostLikeOutOfBoundsUtilities
{
    public static readonly int PageTooSmall = IntOperations.Decrement(PostLikeConfigurations.PageMinValue);
    public static readonly int PageTooLarge = IntOperations.Increment(PostLikeConfigurations.PageMaxValue);

    public static readonly int PageSizeTooSmall = IntOperations.Decrement(PostLikeConfigurations.PageSizeMinValue);
    public static readonly int PageSizeTooLarge = IntOperations.Increment(PostLikeConfigurations.PageSizeMaxValue);
}
