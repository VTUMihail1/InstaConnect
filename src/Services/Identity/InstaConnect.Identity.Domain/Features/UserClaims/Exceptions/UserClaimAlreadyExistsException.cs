using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Exceptions;

public class UserClaimAlreadyExistsException : NotFoundException
{
    public UserClaimAlreadyExistsException(UserClaimId id)
        : base(UserClaimExceptionErrorMessages.GetAlreadyExistsMessage(id))
    {
    }
}
