using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Exceptions;

public class ForgotPasswordTokenExpiredException : BadRequestException
{
    public ForgotPasswordTokenExpiredException(string id, string value)
        : base(ForgotPasswordTokenExceptionErrorMessages.GetExpiredMessage(id, value))
    {
    }
}
