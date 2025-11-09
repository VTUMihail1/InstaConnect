using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Exceptions;

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
