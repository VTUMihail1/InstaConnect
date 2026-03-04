using InstaConnect.Chats.Domain.Features.Users.Models.Responses;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Extensions;

internal static class ChatMessageAggregateFluentExtensions
{
    public static IAggregateFluent<ChatMessage> Match(
        this IAggregateFluent<ChatMessage> aggregate,
        ChatMessagesFilterQuery filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

    public static IAggregateFluent<ChatMessage> Match(
        this IAggregateFluent<ChatMessage> aggregate,
        ChatMessageId filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

    public static IAggregateFluent<ChatMessageResponse> ProjectToFullResponse(
    this IAggregateFluent<ChatMessage> aggregate,
    CurrentUserQuery currentUser)
    {
        var currentUserId = currentUser.Id.Id?.ToLower();
        var projection = Builders<ChatMessage>.Projection.Expression(p =>
            p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId
                ? new ChatMessageResponse(
                    p.Id,
                    p.Content,
                    p.SenderId,
                    new ChatResponse(
                        p.Id.Id,
                        new UserResponse(
                            p.Chat!.ParticipantOne!.Id,
                            p.Chat.ParticipantOne.FirstName,
                            p.Chat.ParticipantOne.LastName,
                            p.Chat.ParticipantOne.Email,
                            p.Chat.ParticipantOne.Name,
                            p.Chat.ParticipantOne.ProfileImage,
                            p.Chat.ParticipantOne.CreatedAtUtc,
                            p.Chat.ParticipantOne.UpdatedAtUtc),
                        new UserResponse(
                            p.Chat.ParticipantTwo!.Id,
                            p.Chat.ParticipantTwo.FirstName,
                            p.Chat.ParticipantTwo.LastName,
                            p.Chat.ParticipantTwo.Email,
                            p.Chat.ParticipantTwo.Name,
                            p.Chat.ParticipantTwo.ProfileImage,
                            p.Chat.ParticipantTwo.CreatedAtUtc,
                            p.Chat.ParticipantTwo.UpdatedAtUtc),
                        p.Chat.CreatedAtUtc),
                    new UserResponse(
                        p.Sender!.Id,
                        p.Sender.FirstName,
                        p.Sender.LastName,
                        p.Sender.Email,
                        p.Sender.Name,
                        p.Sender.ProfileImage,
                        p.Sender.CreatedAtUtc,
                        p.Sender.UpdatedAtUtc),
                    p.CreatedAtUtc,
                    p.UpdatedAtUtc)
                : new ChatMessageResponse(
                    new ChatMessageId(
                        new ChatId(
                            p.Id.Id.ParticipantTwoId,
                            p.Id.Id.ParticipantOneId),
                        p.Id.MessageId),
                    p.Content,
                    p.SenderId,
                    new ChatResponse(
                        new ChatId(
                            p.Id.Id.ParticipantTwoId,
                            p.Id.Id.ParticipantOneId),
                        new UserResponse(
                            p.Chat!.ParticipantTwo!.Id,
                            p.Chat.ParticipantTwo.FirstName,
                            p.Chat.ParticipantTwo.LastName,
                            p.Chat.ParticipantTwo.Email,
                            p.Chat.ParticipantTwo.Name,
                            p.Chat.ParticipantTwo.ProfileImage,
                            p.Chat.ParticipantTwo.CreatedAtUtc,
                            p.Chat.ParticipantTwo.UpdatedAtUtc),
                        new UserResponse(
                            p.Chat.ParticipantOne!.Id,
                            p.Chat.ParticipantOne.FirstName,
                            p.Chat.ParticipantOne.LastName,
                            p.Chat.ParticipantOne.Email,
                            p.Chat.ParticipantOne.Name,
                            p.Chat.ParticipantOne.ProfileImage,
                            p.Chat.ParticipantOne.CreatedAtUtc,
                            p.Chat.ParticipantOne.UpdatedAtUtc),
                        p.Chat.CreatedAtUtc),
                    new UserResponse(
                        p.Sender!.Id,
                        p.Sender.FirstName,
                        p.Sender.LastName,
                        p.Sender.Email,
                        p.Sender.Name,
                        p.Sender.ProfileImage,
                        p.Sender.CreatedAtUtc,
                        p.Sender.UpdatedAtUtc),
                    p.CreatedAtUtc,
                    p.UpdatedAtUtc));

        return aggregate.Project(projection);
    }

    public static IAggregateFluent<ChatMessageResponse> ProjectToResponseWithoutChat(
        this IAggregateFluent<ChatMessage> aggregate,
        CurrentUserQuery currentUser)
    {
        var currentUserId = currentUser.Id.Id?.ToLower();
        var projection = Builders<ChatMessage>.Projection.Expression(p =>
            p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId
                ? new ChatMessageResponse(
                    p.Id,
                    p.Content,
                    p.SenderId,
                    null,
                    new UserResponse(
                        p.Sender!.Id,
                        p.Sender.FirstName,
                        p.Sender.LastName,
                        p.Sender.Email,
                        p.Sender.Name,
                        p.Sender.ProfileImage,
                        p.Sender.CreatedAtUtc,
                        p.Sender.UpdatedAtUtc),
                    p.CreatedAtUtc,
                    p.UpdatedAtUtc)
                : new ChatMessageResponse(
                    new ChatMessageId(
                        new ChatId(
                            p.Id.Id.ParticipantTwoId,
                            p.Id.Id.ParticipantOneId),
                        p.Id.MessageId),
                    p.Content,
                    p.SenderId,
                    null,
                    new UserResponse(
                        p.Sender!.Id,
                        p.Sender.FirstName,
                        p.Sender.LastName,
                        p.Sender.Email,
                        p.Sender.Name,
                        p.Sender.ProfileImage,
                        p.Sender.CreatedAtUtc,
                        p.Sender.UpdatedAtUtc),
                    p.CreatedAtUtc,
                    p.UpdatedAtUtc));

        return aggregate.Project(projection);
    }

    public static IAggregateFluent<ChatMessageResponse> ProjectToResponseWithoutSender(
        this IAggregateFluent<ChatMessage> aggregate,
        CurrentUserQuery currentUser)
    {
        var currentUserId = currentUser.Id.Id?.ToLower();
        var projection = Builders<ChatMessage>.Projection.Expression(p =>
            p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId
                ? new ChatMessageResponse(
                    p.Id,
                    p.Content,
                    p.SenderId,
                    new ChatResponse(
                        p.Id.Id,
                        new UserResponse(
                            p.Chat!.ParticipantOne!.Id,
                            p.Chat.ParticipantOne.FirstName,
                            p.Chat.ParticipantOne.LastName,
                            p.Chat.ParticipantOne.Email,
                            p.Chat.ParticipantOne.Name,
                            p.Chat.ParticipantOne.ProfileImage,
                            p.Chat.ParticipantOne.CreatedAtUtc,
                            p.Chat.ParticipantOne.UpdatedAtUtc),
                        new UserResponse(
                            p.Chat.ParticipantTwo!.Id,
                            p.Chat.ParticipantTwo.FirstName,
                            p.Chat.ParticipantTwo.LastName,
                            p.Chat.ParticipantTwo.Email,
                            p.Chat.ParticipantTwo.Name,
                            p.Chat.ParticipantTwo.ProfileImage,
                            p.Chat.ParticipantTwo.CreatedAtUtc,
                            p.Chat.ParticipantTwo.UpdatedAtUtc),
                        p.Chat.CreatedAtUtc),
                    null,
                    p.CreatedAtUtc,
                    p.UpdatedAtUtc)
                : new ChatMessageResponse(
                    new ChatMessageId(
                        new ChatId(
                            p.Id.Id.ParticipantTwoId,
                            p.Id.Id.ParticipantOneId),
                        p.Id.MessageId),
                    p.Content,
                    p.SenderId,
                    new ChatResponse(
                        new ChatId(
                            p.Id.Id.ParticipantTwoId,
                            p.Id.Id.ParticipantOneId),
                        new UserResponse(
                            p.Chat!.ParticipantTwo!.Id,
                            p.Chat.ParticipantTwo.FirstName,
                            p.Chat.ParticipantTwo.LastName,
                            p.Chat.ParticipantTwo.Email,
                            p.Chat.ParticipantTwo.Name,
                            p.Chat.ParticipantTwo.ProfileImage,
                            p.Chat.ParticipantTwo.CreatedAtUtc,
                            p.Chat.ParticipantTwo.UpdatedAtUtc),
                        new UserResponse(
                            p.Chat.ParticipantOne!.Id,
                            p.Chat.ParticipantOne.FirstName,
                            p.Chat.ParticipantOne.LastName,
                            p.Chat.ParticipantOne.Email,
                            p.Chat.ParticipantOne.Name,
                            p.Chat.ParticipantOne.ProfileImage,
                            p.Chat.ParticipantOne.CreatedAtUtc,
                            p.Chat.ParticipantOne.UpdatedAtUtc),
                        p.Chat.CreatedAtUtc),
                    null,
                    p.CreatedAtUtc,
                    p.UpdatedAtUtc));

        return aggregate.Project(projection);
    }
}
