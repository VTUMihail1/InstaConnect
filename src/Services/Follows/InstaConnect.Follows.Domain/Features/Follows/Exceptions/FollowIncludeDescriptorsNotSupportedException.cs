using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Follows.Domain.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Follows.Exceptions;

public class FollowIncludeDescriptorsNotSupportedException : BadRequestException
{
    public FollowIncludeDescriptorsNotSupportedException(ICollection<FollowsIncludeDescriptor> includeDescriptors)
        : base(FollowExceptionErrorMessages.GetInclideDescriptorsNotSupportedMessage(includeDescriptors))
    {
    }

    public FollowIncludeDescriptorsNotSupportedException(ICollection<FollowsIncludeDescriptor> includeDescriptors, Exception exception)
        : base(FollowExceptionErrorMessages.GetInclideDescriptorsNotSupportedMessage(includeDescriptors), exception)
    {
    }
}
