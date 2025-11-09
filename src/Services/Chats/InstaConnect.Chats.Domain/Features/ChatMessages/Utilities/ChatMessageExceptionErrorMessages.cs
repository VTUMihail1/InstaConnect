using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Utilities;

public static class ChatMessageExceptionErrorMessages
{
    public static string GetNotFoundMessage(string participantOneId, string participantTwoId, string messageId)
    {
        const string Format = "ChatMessage(participantOneId: {0}, participantTwoId: {1}, messageId: {2}) with that id does not exist";
        var result = Format.FormatCurrentCulture(participantOneId, participantTwoId);

        return result;
    }

    public static string GetSortPropertyNotSupportedMessage(ChatMessageSortProperty sortProperty)
    {
        const string Format = "ChatMessageSortProperty(type: {0}) is not supported";
        var result = Format.FormatCurrentCulture(sortProperty);

        return result;
    }

    public static string GetInclidePropertyNotSupportedMessage(ICollection<ChatMessageIncludeProperty> includeProperties)
    {
        const string Format = "ChatMessageIncludeProperties(types: {0}) is not supported";
        var result = Format.FormatCurrentCulture(string.Join(", ", includeProperties));

        return result;
    }
}
