using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Exceptions;

public class EmailConfirmationTokenExpiredException : BadRequestException
{
    public EmailConfirmationTokenExpiredException(string id, string value)
        : base(EmailConfirmationTokenExceptionErrorMessages.GetExpiredMessage(id, value))
    {
    }
}
