using InstaConnect.Common.Exceptions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Exceptions;

public class RefreshTokenNotFoundException : NotFoundException
{
    public RefreshTokenNotFoundException(string id, string value)
        : base(RefreshTokenExceptionErrorMessages.GetNotFoundMessage(id, value))
    {
    }
}
