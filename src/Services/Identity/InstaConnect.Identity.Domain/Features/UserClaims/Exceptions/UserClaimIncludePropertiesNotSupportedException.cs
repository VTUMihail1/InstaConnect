using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Exceptions;

public class UserClaimIncludePropertiesNotSupportedException : BadRequestException
{
    public UserClaimIncludePropertiesNotSupportedException(ICollection<UserClaimIncludeProperty> includeProperties)
        : base(UserClaimExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties))
    {
    }

    public UserClaimIncludePropertiesNotSupportedException(ICollection<UserClaimIncludeProperty> includeProperties, Exception exception)
        : base(UserClaimExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties), exception)
    {
    }
}
