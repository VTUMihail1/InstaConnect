using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Exceptions;

public class UserClaimNotFoundException : NotFoundException
{
    public UserClaimNotFoundException(UserClaimId id)
        : base(UserClaimExceptionErrorMessages.GetNotFoundMessage(id))
    {
    }
}
