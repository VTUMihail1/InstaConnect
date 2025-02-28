using InstaConnect.Common.Exceptions.Base;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Exceptions;

public class ForgotPasswordTokenNotFoundException : NotFoundException
{
    private const string ErrorMessage = "Forgot password token does not exist";

    public ForgotPasswordTokenNotFoundException() : base(ErrorMessage)
    {
    }
}
