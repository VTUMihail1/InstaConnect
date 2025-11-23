using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Utilities;

public static class ChatMessageExceptionErrorMessages
{
    public static string GetNotFoundMessage(ChatMessageId id)
    {
        const string Format = "ChatMessage(participantOneId: {0}, participantTwoId: {1}, messageId: {2}) with that id does not exist";

        return Format.FormatCurrentCulture(id.Id.ParticipantOneId.Id, id.Id.ParticipantTwoId.Id, id.MessageId);
    }

    public static string GetSortPropertyNotSupportedMessage(ChatMessageSortProperty sortProperty)
    {
        const string Format = "ChatMessageSortProperty(type: {0}) is not supported";

        return Format.FormatCurrentCulture(sortProperty);
    }

    public static string GetInclidePropertyNotSupportedMessage(ICollection<ChatMessageIncludeProperty> includeProperties)
    {
        const string Format = "ChatMessageIncludeProperties(types: {0}) is not supported";

        return Format.FormatCurrentCulture(includeProperties.JoinAsStringWithComa());
    }
}
