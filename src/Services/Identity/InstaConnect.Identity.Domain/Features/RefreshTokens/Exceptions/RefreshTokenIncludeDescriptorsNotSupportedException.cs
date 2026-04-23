using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Exceptions;

public class RefreshTokenIncludeDescriptorsNotSupportedException : BadRequestException
{
    public RefreshTokenIncludeDescriptorsNotSupportedException(ICollection<IdentityIncludeDescriptor> includeDescriptors)
        : base(RefreshTokenExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(includeDescriptors))
    {
    }

    public RefreshTokenIncludeDescriptorsNotSupportedException(ICollection<IdentityIncludeDescriptor> includeDescriptors, Exception exception)
        : base(RefreshTokenExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(includeDescriptors), exception)
    {
    }
}
