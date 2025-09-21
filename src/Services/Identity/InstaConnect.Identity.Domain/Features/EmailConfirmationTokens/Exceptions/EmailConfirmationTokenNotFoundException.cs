using InstaConnect.Common.Exceptions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Exceptions;

public class EmailConfirmationTokenNotFoundException : NotFoundException
{
    public EmailConfirmationTokenNotFoundException(string id, string value)
        : base(EmailConfirmationTokenExceptionErrorMessages.GetNotFoundMessage(id, value))
    {
    }
}
