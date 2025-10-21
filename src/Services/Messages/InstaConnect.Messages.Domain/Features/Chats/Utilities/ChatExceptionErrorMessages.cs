using InstaConnect.Common.Extensions;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

namespace InstaConnect.Chats.Common.Features.Chats.Utilities;

public static class ChatExceptionErrorMessages
{
    public static string GetNotFoundMessage(string participantOneId, string participantTwoId)
    {
        const string Format = "Chat(participantOneId: {0}, participantTwoId: {1}) with that id does not exist";
        var result = Format.FormatCurrentCulture(participantOneId, participantTwoId);

        return result;
    }

    public static string GetAlreadyExistsMessage(string participantOneId, string participantTwoId)
    {
        const string Format = "Chat(participantOneId: {0}, participantTwoId: {1}) already exists";
        var result = Format.FormatCurrentCulture(participantOneId, participantTwoId);

        return result;
    }

    public static string GetByParticipantSortPropertyNotSupportedMessage(ChatByParticipantSortProperty sortProperty)
    {
        const string Format = "ChatByParticipantSortProperty(type: {0}) is not supported";
        var result = Format.FormatCurrentCulture(sortProperty);

        return result;
    }

    public static string GetInclidePropertyNotSupportedMessage(ICollection<ChatIncludeProperty> includeProperties)
    {
        const string Format = "ChatIncludeProperties(types: {0}) is not supported";
        var result = Format.FormatCurrentCulture(string.Join(", ", includeProperties));

        return result;
    }
}
