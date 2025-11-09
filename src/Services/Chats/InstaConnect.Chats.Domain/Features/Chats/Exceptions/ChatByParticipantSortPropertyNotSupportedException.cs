using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Chats.Domain.Features.Chats.Exceptions;

public class ChatByParticipantSortPropertyNotSupportedException : BadRequestException
{
    public ChatByParticipantSortPropertyNotSupportedException(ChatByParticipantSortProperty sortProperty)
        : base(ChatExceptionErrorMessages.GetByParticipantSortPropertyNotSupportedMessage(sortProperty))
    {
    }

    public ChatByParticipantSortPropertyNotSupportedException(ChatByParticipantSortProperty sortProperty, Exception exception)
        : base(ChatExceptionErrorMessages.GetByParticipantSortPropertyNotSupportedMessage(sortProperty), exception)
    {
    }
}
