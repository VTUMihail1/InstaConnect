using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Exceptions;

public class EmailConfirmationTokenIncludeDescriptorsNotSupportedException : BadRequestException
{
    public EmailConfirmationTokenIncludeDescriptorsNotSupportedException(ICollection<IdentityIncludeDescriptor> includeDescriptors)
        : base(EmailConfirmationTokenExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(includeDescriptors))
    {
    }

    public EmailConfirmationTokenIncludeDescriptorsNotSupportedException(ICollection<IdentityIncludeDescriptor> includeDescriptors, Exception exception)
        : base(EmailConfirmationTokenExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(includeDescriptors), exception)
    {
    }
}
