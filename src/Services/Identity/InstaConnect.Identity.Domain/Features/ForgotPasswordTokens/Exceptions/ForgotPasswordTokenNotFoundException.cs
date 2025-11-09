using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Exceptions;

public class ForgotPasswordTokenNotFoundException : NotFoundException
{
    public ForgotPasswordTokenNotFoundException(string id, string value)
        : base(ForgotPasswordTokenExceptionErrorMessages.GetNotFoundMessage(id, value))
    {
    }
}
