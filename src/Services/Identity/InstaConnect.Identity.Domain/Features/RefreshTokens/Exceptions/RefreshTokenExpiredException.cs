using InstaConnect.Common.Exceptions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Exceptions;

public class RefreshTokenExpiredException : BadRequestException
{
    public RefreshTokenExpiredException(string id, string value)
        : base(RefreshTokenExceptionErrorMessages.GetExpiredMessage(id, value))
    {
    }
}
