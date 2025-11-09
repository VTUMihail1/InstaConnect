using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Exceptions;

public class RefreshTokenExpiredException : BadRequestException
{
    public RefreshTokenExpiredException(string id, string value)
        : base(RefreshTokenExceptionErrorMessages.GetExpiredMessage(id, value))
    {
    }
}
