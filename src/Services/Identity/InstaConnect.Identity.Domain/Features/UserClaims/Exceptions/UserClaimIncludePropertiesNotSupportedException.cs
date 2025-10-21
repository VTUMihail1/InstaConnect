using InstaConnect.Common.Exceptions;
using InstaConnect.Identity.Domain.Features.Users.Utilities;
using InstaConnect.UserClaims.Domain.Features.UserClaims.Models.Requests;

namespace InstaConnect.UserClaims.Domain.Features.UserClaims.Exceptions;

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
