using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Identity.Domain.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Exceptions;

public class EmailConfirmationTokenIncludeDescriptorsNotSupportedException : BadRequestException
{
    public EmailConfirmationTokenIncludeDescriptorsNotSupportedException(ICollection<IdentityIncludeDescriptor> includeDescriptors)
        : base(EmailConfirmationTokenExceptionErrorMessages.GetInclideDescriptorsNotSupportedMessage(includeDescriptors))
    {
    }

    public EmailConfirmationTokenIncludeDescriptorsNotSupportedException(ICollection<IdentityIncludeDescriptor> includeDescriptors, Exception exception)
        : base(EmailConfirmationTokenExceptionErrorMessages.GetInclideDescriptorsNotSupportedMessage(includeDescriptors), exception)
    {
    }
}
