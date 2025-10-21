using InstaConnect.Common.Exceptions;
using InstaConnect.ForgotPasswordTokens.Common.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.ForgotPasswordTokens.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.ForgotPasswordTokens.Domain.Features.ForgotPasswordTokens.Exceptions;

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
