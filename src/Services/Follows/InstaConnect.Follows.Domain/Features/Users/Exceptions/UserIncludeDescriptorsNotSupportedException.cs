using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;
using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Users.Exceptions;

public class UserIncludeDescriptorsNotSupportedException : BadRequestException
{
	public UserIncludeDescriptorsNotSupportedException(ICollection<FollowsIncludeDescriptor> descriptors)
		: base(UserExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(descriptors))
	{
	}

	public UserIncludeDescriptorsNotSupportedException(ICollection<FollowsIncludeDescriptor> descriptors, Exception exception)
		: base(UserExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(descriptors), exception)
	{
	}
}
