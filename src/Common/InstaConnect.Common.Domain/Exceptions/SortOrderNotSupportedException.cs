using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Domain.Utilities;

namespace InstaConnect.Common.Domain.Exceptions;

public class SortOrderNotSupportedException : BadRequestException
{
    public SortOrderNotSupportedException(CommonSortOrder sortOrder)
        : base(CommonExceptionErrorMessages.GetSortOrderNotSupportedMessage(sortOrder))
    {
    }

    public SortOrderNotSupportedException(CommonSortOrder sortOrder, Exception exception)
        : base(CommonExceptionErrorMessages.GetSortOrderNotSupportedMessage(sortOrder), exception)
    {
    }
}
