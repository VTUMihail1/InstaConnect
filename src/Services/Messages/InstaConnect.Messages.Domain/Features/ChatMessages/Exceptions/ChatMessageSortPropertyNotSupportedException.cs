using InstaConnect.Common.Exceptions;
using InstaConnect.ChatMessages.Common.Features.ChatMessages.Utilities;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;

namespace InstaConnect.Common.Infrastructure.Exceptions;

public class ChatMessageSortPropertyNotSupportedException : BadRequestException
{
    public ChatMessageSortPropertyNotSupportedException(ChatMessageSortProperty sortProperty)
        : base(ChatMessageExceptionErrorMessages.GetSortPropertyNotSupportedMessage(sortProperty))
    {
    }

    public ChatMessageSortPropertyNotSupportedException(ChatMessageSortProperty sortProperty, Exception exception)
        : base(ChatMessageExceptionErrorMessages.GetSortPropertyNotSupportedMessage(sortProperty), exception)
    {
    }
}
