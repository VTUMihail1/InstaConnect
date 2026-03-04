using System.Linq.Expressions;

using InstaConnect.Chats.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

internal static class ChatFilterExtensions
{
    public static FilterDefinition<Chat> GetFilter(this ChatsFilterQuery filter)
    {
        var participantOne = Builders<Chat>.Filter.And(
            filter.ParticipantOneId.GetFilterForIdEquals<Chat>(p => p.Id.ParticipantOneId.Id),
            filter.ParticipantTwoName.GetFilterForNameStartsWith<Chat>(p => p.ParticipantTwo!.Name.Value));
        var participantTwo = Builders<Chat>.Filter.And(
            filter.ParticipantOneId.GetFilterForIdEquals<Chat>(p => p.Id.ParticipantTwoId.Id),
            filter.ParticipantTwoName.GetFilterForNameStartsWith<Chat>(p => p.ParticipantOne!.Name.Value));

        return Builders<Chat>.Filter.Or(participantOne, participantTwo);
    }

    public static FilterDefinition<Chat> GetFilter(this ChatId filter)
    {
        return filter.GetFilterForIdEquals<Chat>(p => p.Id.ParticipantOneId.Id, p => p.Id.ParticipantTwoId.Id);
    }

    public static FilterDefinition<T> GetFilterForIdEquals<T>(
        this ChatId filter,
        Expression<Func<T, object>> participantOneIdField,
        Expression<Func<T, object>> participantTwoIdField)
    {
        var participantOneId = Builders<T>.Filter.And(
            filter.ParticipantOneId.GetFilterForIdEquals(participantOneIdField),
            filter.ParticipantTwoId.GetFilterForIdEquals(participantTwoIdField));
        var participantTwoId = Builders<T>.Filter.And(
            filter.ParticipantTwoId.GetFilterForIdEquals(participantOneIdField),
            filter.ParticipantOneId.GetFilterForIdEquals(participantTwoIdField));

        return Builders<T>.Filter.Or(participantOneId, participantTwoId);
    }
}
