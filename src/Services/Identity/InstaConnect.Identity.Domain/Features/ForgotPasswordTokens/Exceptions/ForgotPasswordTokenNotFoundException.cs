using InstaConnect.Common.Exceptions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Exceptions;

public class ForgotPasswordTokenNotFoundException : NotFoundException
{
    public ForgotPasswordTokenNotFoundException(string id, string value)
        : base(ForgotPasswordTokenExceptionErrorMessages.GetNotFoundMessage(id, value))
    {
    }
}
