using InstaConnect.Common.Exceptions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Utilities;
using InstaConnect.RefreshTokens.Common.Features.RefreshTokens.Utilities;
using InstaConnect.RefreshTokens.Domain.Features.RefreshTokens.Models.Requests;

namespace InstaConnect.RefreshTokens.Domain.Features.RefreshTokens.Exceptions;

public class RefreshTokenIncludePropertiesNotSupportedException : BadRequestException
{
    public RefreshTokenIncludePropertiesNotSupportedException(ICollection<RefreshTokenIncludeProperty> includeProperties)
        : base(RefreshTokenExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties))
    {
    }

    public RefreshTokenIncludePropertiesNotSupportedException(ICollection<RefreshTokenIncludeProperty> includeProperties, Exception exception)
        : base(RefreshTokenExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties), exception)
    {
    }
}
