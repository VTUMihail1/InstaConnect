using InstaConnect.Chats.Domain.Features.Users.Models.Responses;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

internal static class ChatAggregateFluentExtensions
{
    public static IAggregateFluent<Chat> Match(
        this IAggregateFluent<Chat> aggregate,
        ChatsFilterQuery filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

    public static IAggregateFluent<Chat> Match(
        this IAggregateFluent<Chat> aggregate,
        ChatId filter)
    {
        return aggregate.Match(filter.GetFilter());
    }

    public static IAggregateFluent<ChatResponse> ProjectToFullResponse(
        this IAggregateFluent<Chat> aggregate,
        CurrentUserQuery currentUser)
    {
        var currentUserId = currentUser.Id.Id?.ToLower();
        var projection = Builders<Chat>.Projection.Expression(p =>
              p.Id.ParticipantOneId.Id.ToLower() == currentUserId
                  ? new ChatResponse(
                      p.Id,
                      new UserResponse(
                          p.ParticipantOne!.Id,
                          p.ParticipantOne.FirstName,
                          p.ParticipantOne.LastName,
                          p.ParticipantOne.Email,
                          p.ParticipantOne.Name,
                          p.ParticipantOne.ProfileImage,
                          p.ParticipantOne.CreatedAtUtc,
                          p.ParticipantOne.UpdatedAtUtc),
                      new UserResponse(
                          p.ParticipantTwo!.Id,
                          p.ParticipantTwo.FirstName,
                          p.ParticipantTwo.LastName,
                          p.ParticipantTwo.Email,
                          p.ParticipantTwo.Name,
                          p.ParticipantTwo.ProfileImage,
                          p.ParticipantTwo.CreatedAtUtc,
                          p.ParticipantTwo.UpdatedAtUtc),
                      p.CreatedAtUtc)
                  : new ChatResponse(
                      new ChatId(
                          p.Id.ParticipantTwoId,
                          p.Id.ParticipantOneId),
                      new UserResponse(
                          p.ParticipantTwo!.Id,
                          p.ParticipantTwo.FirstName,
                          p.ParticipantTwo.LastName,
                          p.ParticipantTwo.Email,
                          p.ParticipantTwo.Name,
                          p.ParticipantTwo.ProfileImage,
                          p.ParticipantTwo.CreatedAtUtc,
                          p.ParticipantTwo.UpdatedAtUtc),
                      new UserResponse(
                          p.ParticipantOne!.Id,
                          p.ParticipantOne.FirstName,
                          p.ParticipantOne.LastName,
                          p.ParticipantOne.Email,
                          p.ParticipantOne.Name,
                          p.ParticipantOne.ProfileImage,
                          p.ParticipantOne.CreatedAtUtc,
                          p.ParticipantOne.UpdatedAtUtc),
                      p.CreatedAtUtc));

        return aggregate.Project(projection);
    }

    public static IAggregateFluent<ChatResponse> ProjectToResponseWithoutParticipantOne(
        this IAggregateFluent<Chat> aggregate,
        CurrentUserQuery currentUser)
    {
        var currentUserId = currentUser.Id.Id?.ToLower();
        var projection = Builders<Chat>.Projection.Expression(p =>
              p.Id.ParticipantOneId.Id.ToLower() == currentUserId
                  ? new ChatResponse(
                      p.Id,
                      null,
                      new UserResponse(
                          p.ParticipantTwo!.Id,
                          p.ParticipantTwo.FirstName,
                          p.ParticipantTwo.LastName,
                          p.ParticipantTwo.Email,
                          p.ParticipantTwo.Name,
                          p.ParticipantTwo.ProfileImage,
                          p.ParticipantTwo.CreatedAtUtc,
                          p.ParticipantTwo.UpdatedAtUtc),
                      p.CreatedAtUtc)
                  : new ChatResponse(
                      new ChatId(
                          p.Id.ParticipantTwoId,
                          p.Id.ParticipantOneId),
                      null,
                      new UserResponse(
                          p.ParticipantOne!.Id,
                          p.ParticipantOne.FirstName,
                          p.ParticipantOne.LastName,
                          p.ParticipantOne.Email,
                          p.ParticipantOne.Name,
                          p.ParticipantOne.ProfileImage,
                          p.ParticipantOne.CreatedAtUtc,
                          p.ParticipantOne.UpdatedAtUtc),
                      p.CreatedAtUtc));

        return aggregate.Project(projection);
    }

    public static IAggregateFluent<ChatResponse> ProjectToResponseWithoutParticipantTwo(
        this IAggregateFluent<Chat> aggregate,
        CurrentUserQuery currentUser)
    {
        var currentUserId = currentUser.Id.Id?.ToLower();
        var projection = Builders<Chat>.Projection.Expression(p =>
              p.Id.ParticipantOneId.Id.ToLower() == currentUserId
                  ? new ChatResponse(
                      p.Id,
                      new UserResponse(
                          p.ParticipantOne!.Id,
                          p.ParticipantOne.FirstName,
                          p.ParticipantOne.LastName,
                          p.ParticipantOne.Email,
                          p.ParticipantOne.Name,
                          p.ParticipantOne.ProfileImage,
                          p.ParticipantOne.CreatedAtUtc,
                          p.ParticipantOne.UpdatedAtUtc),
                      null,
                      p.CreatedAtUtc)
                  : new ChatResponse(
                      new ChatId(
                          p.Id.ParticipantTwoId,
                          p.Id.ParticipantOneId),
                      new UserResponse(
                          p.ParticipantTwo!.Id,
                          p.ParticipantTwo.FirstName,
                          p.ParticipantTwo.LastName,
                          p.ParticipantTwo.Email,
                          p.ParticipantTwo.Name,
                          p.ParticipantTwo.ProfileImage,
                          p.ParticipantTwo.CreatedAtUtc,
                          p.ParticipantTwo.UpdatedAtUtc),
                      null,
                      p.CreatedAtUtc));

        return aggregate.Project(projection);
    }
}
