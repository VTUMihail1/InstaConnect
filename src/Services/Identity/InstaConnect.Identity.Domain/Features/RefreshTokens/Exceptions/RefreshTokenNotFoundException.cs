using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Exceptions;

public class RefreshTokenNotFoundException : NotFoundException
{
    public RefreshTokenNotFoundException(string id, string value)
        : base(RefreshTokenExceptionErrorMessages.GetNotFoundMessage(id, value))
    {
    }
}
