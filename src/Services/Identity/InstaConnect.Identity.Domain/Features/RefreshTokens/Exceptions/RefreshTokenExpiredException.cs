using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Exceptions;

public class RefreshTokenExpiredException : BadRequestException
{
	public RefreshTokenExpiredException(RefreshTokenId id)
		: base(RefreshTokenExceptionErrorMessages.GetExpiredMessage(id))
	{
	}
}
