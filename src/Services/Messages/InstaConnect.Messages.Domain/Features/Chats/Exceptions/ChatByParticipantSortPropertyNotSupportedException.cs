using InstaConnect.Common.Exceptions;
using InstaConnect.Chats.Common.Features.Chats.Utilities;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

namespace InstaConnect.Common.Infrastructure.Exceptions;

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
