using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Exceptions;

public class ForgotPasswordTokenIncludePropertiesNotSupportedException : BadRequestException
{
    public ForgotPasswordTokenIncludePropertiesNotSupportedException(ICollection<ForgotPasswordTokenIncludeProperty> includeProperties)
        : base(ForgotPasswordTokenExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties))
    {
    }

    public ForgotPasswordTokenIncludePropertiesNotSupportedException(ICollection<ForgotPasswordTokenIncludeProperty> includeProperties, Exception exception)
        : base(ForgotPasswordTokenExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties), exception)
    {
    }
}
