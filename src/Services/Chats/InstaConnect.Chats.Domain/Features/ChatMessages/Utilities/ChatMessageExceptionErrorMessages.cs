using InstaConnect.Chats.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Utilities;

public static class ChatMessageExceptionErrorMessages
{
    public static string GetNotFoundMessage(ChatMessageId id)
    {
        const string Format = "ChatMessage(participantOneId: {0}, participantTwoId: {1}, messageId: {2}) with that id does not exist";

        return Format.FormatCurrentCulture(id.Id.ParticipantOneId.Id, id.Id.ParticipantTwoId.Id, id.MessageId);
    }

    public static string GetForbiddenMessage(ChatMessageId id, UserId senderId)
    {
        const string Format = "ChatMessage(participantOneId: {0}, participantTwoId: {1}, messageId: {2}) is not owned by Sender(id: {3})";

        return Format.FormatCurrentCulture(id.Id.ParticipantOneId.Id, id.Id.ParticipantTwoId.Id, id.MessageId, senderId.Id);
    }

    public static string GetSortTermNotSupportedMessage(ChatMessagesSortTerm sortTerm)
    {
        const string Format = "ChatMessagesSortTerm(type: {0}) is not supported";

        return Format.FormatCurrentCulture(sortTerm);
    }

    public static string GetIncludeDescriptorsNotSupportedMessage(ICollection<ChatsIncludeDescriptor> descriptors)
    {
        const string Format = "ChatMessageIncludeDescriptors({0}) is not supported";

        return Format.FormatCurrentCulture(descriptors
            .JoinIncludeDescriptorsAsStringWithComa<ChatsDestinationType, ChatsIncludeType, ChatsIncludeDescriptor>());
    }
}
