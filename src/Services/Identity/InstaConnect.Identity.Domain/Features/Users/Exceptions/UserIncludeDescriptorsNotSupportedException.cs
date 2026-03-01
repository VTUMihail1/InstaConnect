using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Identity.Domain.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.Users.Exceptions;

public class UserIncludeDescriptorsNotSupportedException : BadRequestException
{
    public UserIncludeDescriptorsNotSupportedException(ICollection<IdentityIncludeDescriptor> includeDescriptors)
        : base(UserExceptionErrorMessages.GetInclideDescriptorsNotSupportedMessage(includeDescriptors))
    {
    }

    public UserIncludeDescriptorsNotSupportedException(ICollection<IdentityIncludeDescriptor> includeDescriptors, Exception exception)
        : base(UserExceptionErrorMessages.GetInclideDescriptorsNotSupportedMessage(includeDescriptors), exception)
    {
    }
}
