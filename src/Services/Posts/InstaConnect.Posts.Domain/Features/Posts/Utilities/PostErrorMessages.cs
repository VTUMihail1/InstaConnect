using InstaConnect.Common.Extensions;

namespace InstaConnect.Posts.Common.Features.Posts.Utilities;

public static class PostErrorMessages
{
    public static string GetIdEmpty()
    {
        const string Message = "Id must not be empty.";

        return Message;
    }

    public static string GetIdTooShort(int length)
    {
        const string Format = "Id length is {0} and it must be at least {1} characters long";
        var result = Format.FormatInvariantCulture(length, PostConfigurations.IdMinLength);

        return result;
    }

    public static string GetIdTooLong(int length)
    {
        const string Format = "Id length is {0} and it must be at most {1} characters long";
        var result = Format.FormatInvariantCulture(length, PostConfigurations.IdMaxLength);

        return result;
    }

    public static string GetTitleEmpty()
    {
        const string Message = "Title must not be empty.";

        return Message;
    }

    public static string GetTitleTooShort(int length)
    {
        const string Format = "Title length is {0} and it must be at least {1} characters long";
        var result = Format.FormatInvariantCulture(length, PostConfigurations.TitleMinLength);

        return result;
    }

    public static string GetTitleTooLong(int length)
    {
        const string Format = "Title length is {0} and it must be at most {1} characters long";
        var result = Format.FormatInvariantCulture(length, PostConfigurations.TitleMaxLength);
        return result;
    }

    public static string GetContentEmpty()
    {
        const string Message = "Content must not be empty.";

        return Message;
    }

    public static string GetContentTooShort(int length)
    {
        const string Format = "Content length is {0} and it must be at least {1} characters long";
        var result = Format.FormatInvariantCulture(length, PostConfigurations.ContentMinLength);

        return result;
    }

    public static string GetContentTooLong(int length)
    {
        const string Format = "Content length is {0} and it must be at most {1} characters long";
        var result = Format.FormatInvariantCulture(length, PostConfigurations.ContentMaxLength);

        return result;
    }

    public static string GetSortPropertyEmpty()
    {
        const string Message = "Sort property must not be empty.";

        return Message;
    }

    public static string GetPageEmpty()
    {
        const string Message = "Page must not be empty.";

        return Message;
    }

    public static string GetPageTooSmall(int page)
    {
        const string Format = "Page value is {0} and it must be at least {1}";
        var result = Format.FormatInvariantCulture(page, PostConfigurations.PageMinValue);

        return result;
    }

    public static string GetPageTooLarge(int page)
    {
        const string Format = "Page value is {0} and it must be at most {1}";
        var result = Format.FormatInvariantCulture(page, PostConfigurations.PageMaxValue);

        return result;
    }

    public static string GetPageSizeEmpty()
    {
        const string Message = "Page size must not be empty.";

        return Message;
    }

    public static string GetPageSizeTooSmall(int pageSize)
    {
        const string Format = "Page size is {0} and it must be at least {1}";
        var result = Format.FormatInvariantCulture(pageSize, PostConfigurations.PageSizeMinValue);

        return result;
    }

    public static string GetPageSizeTooLarge(int pageSize)
    {
        const string Format = "Page size is {0} and it must be at most {1}";
        var result = Format.FormatInvariantCulture(pageSize, PostConfigurations.PageSizeMaxValue);

        return result;
    }
}
