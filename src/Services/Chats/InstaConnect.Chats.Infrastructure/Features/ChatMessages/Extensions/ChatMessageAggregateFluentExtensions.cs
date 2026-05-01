using InstaConnect.Chats.Domain.Features.Users.Models.Responses;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Extensions;

internal static class ChatMessageAggregateFluentExtensions
{
	extension(IAggregateFluent<ChatMessage> aggregate)
	{
		public IAggregateFluent<ChatMessage> Match(ChatMessagesFilterQuery filter)
		{
			return aggregate.Match(filter.GetFilter());
		}

		public IAggregateFluent<ChatMessage> Match(ChatMessageId filter)
		{
			return aggregate.Match(filter.GetFilter());
		}

		public IAggregateFluent<ChatMessageResponse> ProjectToFullResponse(CurrentUserQuery currentUser)
		{
			var currentUserId = currentUser.Id.Id.ToLower();
			var projection = Builders<ChatMessage>.Projection.Expression(p =>
				new ChatMessageResponse(
						new ChatMessageId(
							new ChatId(
									   p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.Id.ParticipantOneId : p.Id.Id.ParticipantTwoId,
									   p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.Id.ParticipantTwoId : p.Id.Id.ParticipantOneId),
							p.Id.MessageId),
						p.Content,
						p.SenderId,
						new ChatResponse(
							new ChatId(
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.Id.ParticipantOneId : p.Id.Id.ParticipantTwoId,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.Id.ParticipantTwoId : p.Id.Id.ParticipantOneId),
							new UserResponse(
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantOne!.Id : p.Chat!.ParticipantTwo!.Id,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantOne!.FirstName : p.Chat!.ParticipantTwo!.FirstName,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantOne!.LastName : p.Chat!.ParticipantTwo!.LastName,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantOne!.Email : p.Chat!.ParticipantTwo!.Email,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantOne!.Name : p.Chat!.ParticipantTwo!.Name,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantOne!.ProfileImage : p.Chat!.ParticipantTwo!.ProfileImage,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantOne!.CreatedAtUtc : p.Chat!.ParticipantTwo!.CreatedAtUtc,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantOne!.UpdatedAtUtc : p.Chat!.ParticipantTwo!.UpdatedAtUtc),
							new UserResponse(
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantTwo!.Id : p.Chat!.ParticipantOne!.Id,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantTwo!.FirstName : p.Chat!.ParticipantOne!.FirstName,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantTwo!.LastName : p.Chat!.ParticipantOne!.LastName,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantTwo!.Email : p.Chat!.ParticipantOne!.Email,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantTwo!.Name : p.Chat!.ParticipantOne!.Name,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantTwo!.ProfileImage : p.Chat!.ParticipantOne!.ProfileImage,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantTwo!.CreatedAtUtc : p.Chat!.ParticipantOne!.CreatedAtUtc,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantTwo!.UpdatedAtUtc : p.Chat!.ParticipantOne!.UpdatedAtUtc),
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

		public IAggregateFluent<ChatMessageResponse> ProjectToResponseWithoutChat(CurrentUserQuery currentUser)
		{
			var currentUserId = currentUser.Id.Id.ToLower();
			var projection = Builders<ChatMessage>.Projection.Expression(p =>
				new ChatMessageResponse(
						new ChatMessageId(
							new ChatId(
									   p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.Id.ParticipantOneId : p.Id.Id.ParticipantTwoId,
									   p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.Id.ParticipantTwoId : p.Id.Id.ParticipantOneId),
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

		public IAggregateFluent<ChatMessageResponse> ProjectToResponseWithoutSender(CurrentUserQuery currentUser)
		{
			var currentUserId = currentUser.Id.Id.ToLower();
			var projection = Builders<ChatMessage>.Projection.Expression(p =>
				new ChatMessageResponse(
						new ChatMessageId(
							new ChatId(
									   p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.Id.ParticipantOneId : p.Id.Id.ParticipantTwoId,
									   p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.Id.ParticipantTwoId : p.Id.Id.ParticipantOneId),
							p.Id.MessageId),
						p.Content,
						p.SenderId,
						new ChatResponse(
							new ChatId(
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.Id.ParticipantOneId : p.Id.Id.ParticipantTwoId,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Id.Id.ParticipantTwoId : p.Id.Id.ParticipantOneId),
							new UserResponse(
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantOne!.Id : p.Chat!.ParticipantTwo!.Id,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantOne!.FirstName : p.Chat!.ParticipantTwo!.FirstName,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantOne!.LastName : p.Chat!.ParticipantTwo!.LastName,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantOne!.Email : p.Chat!.ParticipantTwo!.Email,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantOne!.Name : p.Chat!.ParticipantTwo!.Name,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantOne!.ProfileImage : p.Chat!.ParticipantTwo!.ProfileImage,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantOne!.CreatedAtUtc : p.Chat!.ParticipantTwo!.CreatedAtUtc,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantOne!.UpdatedAtUtc : p.Chat!.ParticipantTwo!.UpdatedAtUtc),
							new UserResponse(
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantTwo!.Id : p.Chat!.ParticipantOne!.Id,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantTwo!.FirstName : p.Chat!.ParticipantOne!.FirstName,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantTwo!.LastName : p.Chat!.ParticipantOne!.LastName,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantTwo!.Email : p.Chat!.ParticipantOne!.Email,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantTwo!.Name : p.Chat!.ParticipantOne!.Name,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantTwo!.ProfileImage : p.Chat!.ParticipantOne!.ProfileImage,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantTwo!.CreatedAtUtc : p.Chat!.ParticipantOne!.CreatedAtUtc,
								p.Id.Id.ParticipantOneId.Id.ToLower() == currentUserId ? p.Chat!.ParticipantTwo!.UpdatedAtUtc : p.Chat!.ParticipantOne!.UpdatedAtUtc),
							p.CreatedAtUtc),
						null,
						p.CreatedAtUtc,
						p.UpdatedAtUtc));

			return aggregate.Project(projection);
		}

	}
}
