using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;
using InstaConnect.Chats.Events.Features.Chats;
using InstaConnect.Chats.Tests.Features.Users.Utilities;
using InstaConnect.Common.Domain.Features.Common.Extensions;

namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public static class ChatEquals
{
	extension(Chat? entity)
	{
		public bool Matches(ChatEventRequest request)
		{
			return entity != null &&
				   entity.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId) &&
				   entity.ParticipantOne.Matches(request.ParticipantOne) &&
				   entity.ParticipantTwo.Matches(request.ParticipantTwo) &&
				   entity.CreatedAtUtc == request.CreatedAtUtc;
		}

		public bool Matches(ChatNotificationRequest request)
		{
			return entity != null &&
				   entity.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId) &&
				   entity.ParticipantOne.Matches(request.ParticipantOne) &&
				   entity.ParticipantTwo.Matches(request.ParticipantTwo) &&
				   entity.CreatedAtUtc == request.CreatedAtUtc;
		}
	}

	extension(Chat entity)
	{
		public bool Matches(Chat chat)
		{
			return entity.Id.Matches(chat.Id) &&
				   entity.CreatedAtUtc == chat.CreatedAtUtc;
		}
	}

	extension(ChatId p)
	{
		public bool Matches(ChatId id)
		{
			return p.Matches(id.ParticipantOneId.Id, id.ParticipantTwoId.Id);
		}

		public bool Matches(string participantOneId, string participantTwoId)
		{
			return p.ParticipantOneId.Id.EqualsOrdinalIgnoreCase(participantOneId) &&
				   p.ParticipantTwoId.Id.EqualsOrdinalIgnoreCase(participantTwoId);
		}
	}
}
