using InstaConnect.Common.Exceptions;
using InstaConnect.Common.Models.Enums;
using InstaConnect.Common.Utilities;

namespace InstaConnect.Common.Infrastructure.Exceptions;
public class SortOrderNotSupportedException : BadRequestException
{
    public SortOrderNotSupportedException(SortOrder sortOrder)
        : base(CommonExceptionErrorMessages.GetSortOrderNotSupportedMessage(sortOrder))
    {
    }

    public SortOrderNotSupportedException(SortOrder sortOrder, Exception exception)
        : base(CommonExceptionErrorMessages.GetSortOrderNotSupportedMessage(sortOrder), exception)
    {
    }
}
