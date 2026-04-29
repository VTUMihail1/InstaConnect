using InstaConnect.Common.Domain.Features.ExceptionHandling.Utilities;

namespace InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

public class InvalidValidationException : Exception
{
	public IEnumerable<string> Errors { get; }

	public InvalidValidationException(IEnumerable<string> errors)
		: base(CommonExceptionErrorMessages.GetInvalidValidation())
	{
		Errors = errors;
	}

	public InvalidValidationException(IEnumerable<string> errors, Exception exception)
		: base(CommonExceptionErrorMessages.GetInvalidValidation(), exception)
	{
		Errors = errors;
	}
}
