using InstaConnect.Common.Exceptions;
using InstaConnect.EmailConfirmationTokens.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Utilities;

namespace InstaConnect.EmailConfirmationTokens.Domain.Features.EmailConfirmationTokens.Exceptions;

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
