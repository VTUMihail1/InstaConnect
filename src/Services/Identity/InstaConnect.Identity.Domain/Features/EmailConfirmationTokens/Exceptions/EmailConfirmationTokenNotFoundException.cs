using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Exceptions;

public class EmailConfirmationTokenNotFoundException : NotFoundException
{
    public EmailConfirmationTokenNotFoundException(string id, string value)
        : base(EmailConfirmationTokenExceptionErrorMessages.GetNotFoundMessage(id, value))
    {
    }
}
