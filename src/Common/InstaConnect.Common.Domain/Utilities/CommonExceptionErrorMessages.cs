using InstaConnect.Common.Extensions;
using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Posts.Domain.Features.Posts.Utilities;
public static class CommonExceptionErrorMessages
{
    public static string GetSortOrderNotSupportedMessage(SortOrder sortOrder)
    {
        const string Format = "SortOrder(type: {0}) is not supported";
        var result = Format.FormatInvariant(sortOrder);

        return result;
    }
}
