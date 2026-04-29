using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Exceptions;

public class RefreshTokenNotFoundException : NotFoundException
{
	public RefreshTokenNotFoundException(RefreshTokenId id)
		: base(RefreshTokenExceptionErrorMessages.GetNotFoundMessage(id))
	{
	}
}
