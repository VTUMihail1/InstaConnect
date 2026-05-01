using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;
using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Follows.Exceptions;

public class FollowIncludeDescriptorsNotSupportedException : BadRequestException
{
	public FollowIncludeDescriptorsNotSupportedException(ICollection<FollowsIncludeDescriptor> includeDescriptors)
		: base(FollowExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(includeDescriptors))
	{
	}

	public FollowIncludeDescriptorsNotSupportedException(ICollection<FollowsIncludeDescriptor> includeDescriptors, Exception exception)
		: base(FollowExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(includeDescriptors), exception)
	{
	}
}
