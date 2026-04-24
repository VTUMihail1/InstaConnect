using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;
using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Exceptions;

public class ForgotPasswordTokenIncludeDescriptorsNotSupportedException : BadRequestException
{
    public ForgotPasswordTokenIncludeDescriptorsNotSupportedException(ICollection<IdentityIncludeDescriptor> includeDescriptors)
        : base(ForgotPasswordTokenExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(includeDescriptors))
    {
    }

    public ForgotPasswordTokenIncludeDescriptorsNotSupportedException(ICollection<IdentityIncludeDescriptor> includeDescriptors, Exception exception)
        : base(ForgotPasswordTokenExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(includeDescriptors), exception)
    {
    }
}
