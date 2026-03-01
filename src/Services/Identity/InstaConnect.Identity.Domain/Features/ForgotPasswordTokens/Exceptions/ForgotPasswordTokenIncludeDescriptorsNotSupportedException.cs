using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Identity.Domain.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Exceptions;

public class ForgotPasswordTokenIncludeDescriptorsNotSupportedException : BadRequestException
{
    public ForgotPasswordTokenIncludeDescriptorsNotSupportedException(ICollection<IdentityIncludeDescriptor> includeDescriptors)
        : base(ForgotPasswordTokenExceptionErrorMessages.GetInclideDescriptorsNotSupportedMessage(includeDescriptors))
    {
    }

    public ForgotPasswordTokenIncludeDescriptorsNotSupportedException(ICollection<IdentityIncludeDescriptor> includeDescriptors, Exception exception)
        : base(ForgotPasswordTokenExceptionErrorMessages.GetInclideDescriptorsNotSupportedMessage(includeDescriptors), exception)
    {
    }
}
