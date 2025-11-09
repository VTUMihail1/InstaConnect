using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Exceptions;

public class EmailConfirmationTokenIncludePropertiesNotSupportedException : BadRequestException
{
    public EmailConfirmationTokenIncludePropertiesNotSupportedException(ICollection<EmailConfirmationTokenIncludeProperty> includeProperties)
        : base(EmailConfirmationTokenExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties))
    {
    }

    public EmailConfirmationTokenIncludePropertiesNotSupportedException(ICollection<EmailConfirmationTokenIncludeProperty> includeProperties, Exception exception)
        : base(EmailConfirmationTokenExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties), exception)
    {
    }
}
