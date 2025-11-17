using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Exceptions;

public class EmailConfirmationTokenNotFoundException : NotFoundException
{
    public EmailConfirmationTokenNotFoundException(EmailConfirmationTokenId id)
        : base(EmailConfirmationTokenExceptionErrorMessages.GetNotFoundMessage(id))
    {
    }
}
