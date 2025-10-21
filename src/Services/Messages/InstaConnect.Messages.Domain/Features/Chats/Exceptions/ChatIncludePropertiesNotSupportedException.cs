using InstaConnect.Common.Exceptions;
using InstaConnect.Chats.Common.Features.Chats.Utilities;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

namespace InstaConnect.Chats.Domain.Features.Chats.Exceptions;

public class ChatIncludePropertiesNotSupportedException : BadRequestException
{
    public ChatIncludePropertiesNotSupportedException(ICollection<ChatIncludeProperty> includeProperties)
        : base(ChatExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties))
    {
    }

    public ChatIncludePropertiesNotSupportedException(ICollection<ChatIncludeProperty> includeProperties, Exception exception)
        : base(ChatExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties), exception)
    {
    }
}
