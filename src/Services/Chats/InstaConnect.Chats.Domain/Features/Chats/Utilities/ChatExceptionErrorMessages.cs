using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Chats.Domain.Features.Chats.Utilities;

public static class ChatExceptionErrorMessages
{
    public static string GetNotFoundMessage(ChatId id)
    {
        const string Format = "Chat(participantOneId: {0}, participantTwoId: {1}) with that id does not exist";

        return Format.FormatCurrentCulture(id.ParticipantOneId.Id, id.ParticipantTwoId.Id);
    }

    public static string GetAlreadyExistsMessage(ChatId id)
    {
        const string Format = "Chat(participantOneId: {0}, participantTwoId: {1}) already exists";

        return Format.FormatCurrentCulture(id.ParticipantOneId.Id, id.ParticipantTwoId.Id);
    }

    public static string GetForbiddenMessage(ChatId id, UserId participantId)
    {
        const string Format = "Chat(participantOneId: {0}, participantTwoId: {1}) does not have Participant(id: {2})";

        return Format.FormatCurrentCulture(id.ParticipantOneId.Id, id.ParticipantTwoId.Id, participantId.Id);
    }

    public static string GetByParticipantSortPropertyNotSupportedMessage(ChatByParticipantSortProperty sortProperty)
    {
        const string Format = "ChatByParticipantSortProperty(type: {0}) is not supported";

        return Format.FormatCurrentCulture(sortProperty);
    }

    public static string GetInclidePropertyNotSupportedMessage(ICollection<ChatIncludeProperty> includeProperties)
    {
        const string Format = "ChatIncludeProperties(types: {0}) is not supported";

        return Format.FormatCurrentCulture(includeProperties.JoinAsStringWithComa());
    }
}
