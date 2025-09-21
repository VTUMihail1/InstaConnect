using InstaConnect.Common.Exceptions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Exceptions;

public class ForgotPasswordTokenExpiredException : BadRequestException
{
    public ForgotPasswordTokenExpiredException(string id, string value)
        : base(ForgotPasswordTokenExceptionErrorMessages.GetExpiredMessage(id, value))
    {
    }
}
