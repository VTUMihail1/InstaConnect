using InstaConnect.Common.Exceptions;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Exceptions;

public class EmailConfirmationTokenNotFoundException : NotFoundException
{
    private const string ErrorMessage = "Email confirmation token does not exist";

    public EmailConfirmationTokenNotFoundException() : base(ErrorMessage)
    {
    }
}
