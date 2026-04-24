using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Exceptions;

public class EmailConfirmationTokenExpiredException : BadRequestException
{
    public EmailConfirmationTokenExpiredException(EmailConfirmationTokenId id)
        : base(EmailConfirmationTokenExceptionErrorMessages.GetExpiredMessage(id))
    {
    }
}
