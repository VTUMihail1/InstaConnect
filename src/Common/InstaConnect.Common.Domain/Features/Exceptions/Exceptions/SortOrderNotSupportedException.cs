using InstaConnect.Common.Domain.Features.Exceptions.Utilities;
using InstaConnect.Common.Domain.Features.Requests.Models;

namespace InstaConnect.Common.Domain.Features.Exceptions.Exceptions;

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
