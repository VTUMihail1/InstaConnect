using InstaConnect.Common.Exceptions;
using InstaConnect.ChatMessages.Common.Features.ChatMessages.Utilities;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;

namespace InstaConnect.ChatMessages.Domain.Features.ChatMessages.Exceptions;

public class ChatMessageIncludePropertiesNotSupportedException : BadRequestException
{
    public ChatMessageIncludePropertiesNotSupportedException(ICollection<ChatMessageIncludeProperty> includeProperties)
        : base(ChatMessageExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties))
    {
    }

    public ChatMessageIncludePropertiesNotSupportedException(ICollection<ChatMessageIncludeProperty> includeProperties, Exception exception)
        : base(ChatMessageExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties), exception)
    {
    }
}
