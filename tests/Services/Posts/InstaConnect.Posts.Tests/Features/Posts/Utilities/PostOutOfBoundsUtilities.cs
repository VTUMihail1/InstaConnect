namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public static class PostOutOfBoundsUtilities
{
    public static readonly int IdTooShort = IntOperations.Decrement(PostConfigurations.IdMinLength);
    public static readonly int IdTooLong = IntOperations.Increment(PostConfigurations.IdMaxLength);

    public static readonly int TitleTooShort = IntOperations.Decrement(PostConfigurations.TitleMinLength);
    public static readonly int TitleTooLong = IntOperations.Increment(PostConfigurations.TitleMaxLength);

    public static readonly int ContentTooShort = IntOperations.Decrement(PostConfigurations.ContentMinLength);
    public static readonly int ContentTooLong = IntOperations.Increment(PostConfigurations.ContentMaxLength);

    public static readonly int PageTooSmall = IntOperations.Decrement(PostConfigurations.PageMinValue);
    public static readonly int PageTooLarge = IntOperations.Increment(PostConfigurations.PageMaxValue);

    public static readonly int PageSizeTooSmall = IntOperations.Decrement(PostConfigurations.PageSizeMinValue);
    public static readonly int PageSizeTooLarge = IntOperations.Increment(PostConfigurations.PageSizeMaxValue);
}
