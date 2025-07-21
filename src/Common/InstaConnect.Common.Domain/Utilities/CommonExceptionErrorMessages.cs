using InstaConnect.Common.Extensions;
using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Common.Utilities;

public static class CommonExceptionErrorMessages
{
    public static readonly string GetSortOrderEmpty()
    {
        const string Message = "Sort order must not be empty.";

        return Message;
    }

    public static string GetSortOrderNotSupportedMessage(SortOrder sortOrder)
    {
        const string Format = "SortOrder(type: {0}) is not supported";
        var result = Format.FormatInvariant(sortOrder);

        return result;
    }
}
