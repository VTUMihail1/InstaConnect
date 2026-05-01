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
			var currentUserId = currentUser.Id.Id.ToLower();
			var projection = Builders<Chat>.Projection.Expression(p =>
					   new ChatResponse(
								   new ChatId(
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.ParticipantOneId : p.Id.ParticipantTwoId,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.ParticipantTwoId : p.Id.ParticipantOneId),
								   new UserResponse(
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.Id : p.ParticipantTwo!.Id,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.FirstName : p.ParticipantTwo!.FirstName,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.LastName : p.ParticipantTwo!.LastName,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.Email : p.ParticipantTwo!.Email,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.Name : p.ParticipantTwo!.Name,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.ProfileImage : p.ParticipantTwo!.ProfileImage,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.CreatedAtUtc : p.ParticipantTwo!.CreatedAtUtc,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.UpdatedAtUtc : p.ParticipantTwo!.UpdatedAtUtc),
								   new UserResponse(
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.Id : p.ParticipantOne!.Id,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.FirstName : p.ParticipantOne!.FirstName,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.LastName : p.ParticipantOne!.LastName,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.Email : p.ParticipantOne!.Email,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.Name : p.ParticipantOne!.Name,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.ProfileImage : p.ParticipantOne!.ProfileImage,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.CreatedAtUtc : p.ParticipantOne!.CreatedAtUtc,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.UpdatedAtUtc : p.ParticipantOne!.UpdatedAtUtc),
								   p.CreatedAtUtc));

			return aggregate.Project(projection);
		}

		public IAggregateFluent<ChatResponse> ProjectToResponseWithoutParticipantOne(CurrentUserQuery currentUser)
		{
			var currentUserId = currentUser.Id.Id.ToLower();
			var projection = Builders<Chat>.Projection.Expression(p =>
					   new ChatResponse(
								   new ChatId(
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.ParticipantOneId : p.Id.ParticipantTwoId,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.ParticipantTwoId : p.Id.ParticipantOneId),
								   null,
								   new UserResponse(
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.Id : p.ParticipantOne!.Id,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.FirstName : p.ParticipantOne!.FirstName,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.LastName : p.ParticipantOne!.LastName,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.Email : p.ParticipantOne!.Email,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.Name : p.ParticipantOne!.Name,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.ProfileImage : p.ParticipantOne!.ProfileImage,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.CreatedAtUtc : p.ParticipantOne!.CreatedAtUtc,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantTwo!.UpdatedAtUtc : p.ParticipantOne!.UpdatedAtUtc),
								   p.CreatedAtUtc));

			return aggregate.Project(projection);
		}

		public IAggregateFluent<ChatResponse> ProjectToResponseWithoutParticipantTwo(CurrentUserQuery currentUser)
		{
			var currentUserId = currentUser.Id.Id.ToLower();
			var projection = Builders<Chat>.Projection.Expression(p =>
					   new ChatResponse(
								   new ChatId(
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.ParticipantOneId : p.Id.ParticipantTwoId,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.ParticipantTwoId : p.Id.ParticipantOneId),
								   new UserResponse(
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.Id : p.ParticipantTwo!.Id,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.FirstName : p.ParticipantTwo!.FirstName,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.LastName : p.ParticipantTwo!.LastName,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.Email : p.ParticipantTwo!.Email,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.Name : p.ParticipantTwo!.Name,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.ProfileImage : p.ParticipantTwo!.ProfileImage,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.CreatedAtUtc : p.ParticipantTwo!.CreatedAtUtc,
									   p.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.ParticipantOne!.UpdatedAtUtc : p.ParticipantTwo!.UpdatedAtUtc),
								   null,
								   p.CreatedAtUtc));

			return aggregate.Project(projection);
		}
	}
}
