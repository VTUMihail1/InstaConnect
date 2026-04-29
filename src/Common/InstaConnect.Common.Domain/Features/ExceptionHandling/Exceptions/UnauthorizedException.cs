using InstaConnect.Common.Domain.Features.ExceptionHandling.Models;

namespace InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

public class UnauthorizedException : BaseException
{
	protected UnauthorizedException(string message) : base(message, BaseExceptionStatus.Unauthorized)
	{
	}

	protected UnauthorizedException(string message, Exception exception) : base(message, BaseExceptionStatus.Unauthorized, exception)
	{
	}
}
