namespace InstaConnect.Posts.Common.Features.Posts.Utilities;

public static class PostErrorMessages
{
    public static readonly string IdEmpty = $"Id must not be empty.";
    public static readonly string IdTooShort = $"Id must be at least {PostConfigurations.IdMinLength} characters long.";
    public static readonly string IdTooLong = $"Id must be at most {PostConfigurations.IdMaxLength} characters long.";

    public static readonly string TitleEmpty = $"Title must not be empty.";
    public static readonly string TitleTooShort = $"Title must be at least {PostConfigurations.TitleMinLength} characters long.";
    public static readonly string TitleTooLong = $"Title must be at most {PostConfigurations.TitleMaxLength} characters long.";

    public static readonly string ContentEmpty = $"Content must not be empty.";
    public static readonly string ContentTooShort = $"Content must be at least {PostConfigurations.ContentMinLength} characters long.";
    public static readonly string ContentTooLong = $"Content must be at most {PostConfigurations.ContentMaxLength} characters long.";

    public static readonly string SortPropertyEmpty = $"Sort property must not be empty.";

    public static readonly string PageTooSmall = $"Page must be at least {PostConfigurations.PageMinValue}.";
    public static readonly string PageTooLarge = $"Page must be at most {PostConfigurations.PageMaxValue}.";

    public static readonly string PageSizeTooSmall = $"Page size must be at least {PostConfigurations.PageSizeMinValue}.";
    public static readonly string PageSizeTooLarge = $"Page size must be at most {PostConfigurations.PageSizeMaxValue}.";
}
