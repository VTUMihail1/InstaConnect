using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;
using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Exceptions;

public class UserClaimIncludeDescriptorsNotSupportedException : BadRequestException
{
	public UserClaimIncludeDescriptorsNotSupportedException(ICollection<IdentityIncludeDescriptor> includeDescriptors)
		: base(UserClaimExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(includeDescriptors))
	{
	}

	public UserClaimIncludeDescriptorsNotSupportedException(ICollection<IdentityIncludeDescriptor> includeDescriptors, Exception exception)
		: base(UserClaimExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(includeDescriptors), exception)
	{
	}
}
