using InstaConnect.Common.Domain.Features.ExceptionHandling.Models;

namespace InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

public class BadRequestException : BaseException
{
	public BadRequestException(string message) : base(message, BaseExceptionStatus.BadRequest)
	{
	}

	public BadRequestException(string message, Exception exception) : base(message, BaseExceptionStatus.BadRequest, exception)
	{
	}
}
