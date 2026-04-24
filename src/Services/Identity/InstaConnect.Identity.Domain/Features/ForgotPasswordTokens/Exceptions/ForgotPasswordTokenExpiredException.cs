using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Exceptions;

public class ForgotPasswordTokenExpiredException : BadRequestException
{
    public ForgotPasswordTokenExpiredException(ForgotPasswordTokenId id)
        : base(ForgotPasswordTokenExceptionErrorMessages.GetExpiredMessage(id))
    {
    }
}
