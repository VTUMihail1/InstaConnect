using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Identity.Domain.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Exceptions;

public class RefreshTokenIncludeDescriptorsNotSupportedException : BadRequestException
{
    public RefreshTokenIncludeDescriptorsNotSupportedException(ICollection<IdentityIncludeDescriptor> includeDescriptors)
        : base(RefreshTokenExceptionErrorMessages.GetInclideDescriptorsNotSupportedMessage(includeDescriptors))
    {
    }

    public RefreshTokenIncludeDescriptorsNotSupportedException(ICollection<IdentityIncludeDescriptor> includeDescriptors, Exception exception)
        : base(RefreshTokenExceptionErrorMessages.GetInclideDescriptorsNotSupportedMessage(includeDescriptors), exception)
    {
    }
}
