using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Common.Domain.Utilities;

public static class CommonExceptionErrorMessages
{
    public static string GetSortOrderEmpty()
    {
        const string Message = "Sort order must not be empty.";

        return Message;
    }

    public static string GetSortOrderNotSupportedMessage(SortOrder sortOrder)
    {
        const string Format = "SortOrder(type: {0}) is not supported";
        var result = Format.FormatCurrentCulture(sortOrder);

        return result;
    }
}
