using InstaConnect.Common.Extensions;

namespace InstaConnect.Chats.Common.Features.Chats.Utilities;

public static class ChatErrorMessages
{
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
        var result = Format.FormatCurrentCulture(page, ChatConfigurations.PageMinValue);

        return result;
    }

    public static string GetPageTooLarge(int page)
    {
        const string Format = "Page value is {0} and it must be at most {1}";
        var result = Format.FormatCurrentCulture(page, ChatConfigurations.PageMaxValue);

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
        var result = Format.FormatCurrentCulture(pageSize, ChatConfigurations.PageSizeMinValue);

        return result;
    }

    public static string GetPageSizeTooLarge(int pageSize)
    {
        const string Format = "Page size is {0} and it must be at most {1}";
        var result = Format.FormatCurrentCulture(pageSize, ChatConfigurations.PageSizeMaxValue);

        return result;
    }
}
