using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Exceptions;

public class UserClaimAlreadyExistsException : BadRequestException
{
	public UserClaimAlreadyExistsException(UserClaimId id)
		: base(UserClaimExceptionErrorMessages.GetAlreadyExistsMessage(id))
	{
	}
}
