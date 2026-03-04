using System.Linq.Expressions;

using InstaConnect.Chats.Infrastructure.Features.ChatMessages.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Extensions;

public static class ChatMessageFilterExtensions
{
    public static FilterDefinition<ChatMessage> GetFilter(this ChatMessagesFilterQuery filter)
    {
        return filter.Id.GetFilterForIdEquals<ChatMessage>(
            p => p.Id.Id.ParticipantOneId.Id, p => p.Id.Id.ParticipantTwoId.Id);
    }

    public static FilterDefinition<ChatMessage> GetFilter(this ChatMessageId filter)
    {
        return filter.GetFilterForIdEquals<ChatMessage>(
            p => p.Id.Id.ParticipantOneId.Id,
            p => p.Id.Id.ParticipantTwoId.Id,
            p => p.Id.MessageId);
    }

    public static FilterDefinition<T> GetFilterForIdEquals<T>(
        this ChatMessageId filter,
        Expression<Func<T, object>> participantOneIdField,
        Expression<Func<T, object>> participantTwoIdField,
        Expression<Func<T, object>> messageIdField)
    {
        var chatId = filter.Id.GetFilterForIdEquals(participantOneIdField, participantTwoIdField);
        var messageId = Builders<T>.Filter.EqualsCaseInsensitive(
            messageIdField, filter.MessageId, filter.MessageId.IsNullOrEmptyOrWhiteSpace());

        return Builders<T>.Filter.And(chatId, messageId);
    }
}
