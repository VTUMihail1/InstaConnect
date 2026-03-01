using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Identity.Domain.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Exceptions;

public class UserClaimIncludeDescriptorsNotSupportedException : BadRequestException
{
    public UserClaimIncludeDescriptorsNotSupportedException(ICollection<IdentityIncludeDescriptor> includeDescriptors)
        : base(UserClaimExceptionErrorMessages.GetInclideDescriptorsNotSupportedMessage(includeDescriptors))
    {
    }

    public UserClaimIncludeDescriptorsNotSupportedException(ICollection<IdentityIncludeDescriptor> includeDescriptors, Exception exception)
        : base(UserClaimExceptionErrorMessages.GetInclideDescriptorsNotSupportedMessage(includeDescriptors), exception)
    {
    }
}
