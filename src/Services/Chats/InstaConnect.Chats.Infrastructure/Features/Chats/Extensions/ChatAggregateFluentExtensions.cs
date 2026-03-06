using InstaConnect.Chats.Domain.Features.Users.Models.Responses;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

internal static class ChatAggregateFluentExtensions
{
    extension(IAggregateFluent<Chat> aggregate)
    {
        public IAggregateFluent<Chat> Match(ChatsFilterQuery filter)
        {
            return aggregate.Match(filter.GetFilter());
        }

        public IAggregateFluent<Chat> Match(ChatId filter)
        {
            return aggregate.Match(filter.GetFilter());
        }

        public IAggregateFluent<ChatResponse> ProjectToFullResponse(CurrentUserQuery currentUser)
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

        public IAggregateFluent<ChatResponse> ProjectToResponseWithoutParticipantOne(CurrentUserQuery currentUser)
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

        public IAggregateFluent<ChatResponse> ProjectToResponseWithoutParticipantTwo(CurrentUserQuery currentUser)
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
}
