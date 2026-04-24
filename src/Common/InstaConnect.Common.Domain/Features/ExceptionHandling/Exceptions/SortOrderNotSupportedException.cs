using InstaConnect.Common.Domain.Features.ExceptionHandling.Utilities;
using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

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
