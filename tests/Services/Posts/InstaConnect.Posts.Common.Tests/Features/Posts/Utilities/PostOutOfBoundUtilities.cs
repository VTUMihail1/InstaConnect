using InstaConnect.Common.Extensions;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

public static class PostOutOfBoundUtilities
{
    public static readonly int IdTooShort = PostConfigurations.IdMinLength.Decrement();
    public static readonly int IdTooLong = PostConfigurations.IdMaxLength.Increment();

    public static readonly int TitleTooShort = PostConfigurations.TitleMinLength.Decrement();
    public static readonly int TitleTooLong = PostConfigurations.TitleMaxLength.Increment();

    public static readonly int ContentTooShort = PostConfigurations.ContentMinLength.Decrement();
    public static readonly int ContentTooLong = PostConfigurations.ContentMaxLength.Increment();

    public static readonly int PageTooSmall = PostConfigurations.PageMinValue.Decrement();
    public static readonly int PageTooLarge = PostConfigurations.PageMaxValue.Increment();

    public static readonly int PageSizeTooSmall = PostConfigurations.PageSizeMinValue.Decrement();
    public static readonly int PageSizeTooLarge = PostConfigurations.PageSizeMaxValue.Increment();
}
