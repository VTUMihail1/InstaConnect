using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Exceptions;

public class EmailConfirmationTokenNotFoundException : NotFoundException
{
	public EmailConfirmationTokenNotFoundException(EmailConfirmationTokenId id)
		: base(EmailConfirmationTokenExceptionErrorMessages.GetNotFoundMessage(id))
	{
	}
}
