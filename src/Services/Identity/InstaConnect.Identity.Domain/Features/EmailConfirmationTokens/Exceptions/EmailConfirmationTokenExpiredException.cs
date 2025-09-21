using InstaConnect.Common.Exceptions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Exceptions;

public class EmailConfirmationTokenExpiredException : BadRequestException
{
    public EmailConfirmationTokenExpiredException(string id, string value)
        : base(EmailConfirmationTokenExceptionErrorMessages.GetExpiredMessage(id, value))
    {
    }
}
