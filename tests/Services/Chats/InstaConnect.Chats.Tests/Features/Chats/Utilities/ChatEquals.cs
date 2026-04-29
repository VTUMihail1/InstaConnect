using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;
using InstaConnect.Chats.Events.Features.Chats;
using InstaConnect.Chats.Tests.Features.Users.Utilities;
using InstaConnect.Common.Domain.Features.Common.Extensions;

namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public static class ChatEquals
{
	extension(ChatAddedEventRequest request)
	{
		public bool Matches(Chat entity)
		{
			return entity.Matches(request.Chat);
		}
	}

	extension(ChatEventRequest r)
	{
		public bool Matches(ChatEventRequest request)
		{
			return r.ParticipantOneId == request.ParticipantOneId &&
				   r.ParticipantTwoId == request.ParticipantTwoId &&
				   r.ParticipantOne.Matches(request.ParticipantOne) &&
				   r.ParticipantTwo.Matches(request.ParticipantTwo) &&
				   r.CreatedAtUtc == request.CreatedAtUtc;
		}
	}

	extension(Chat entity)
	{
		public bool Matches(ChatEventRequest request)
		{
			return entity.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId) &&
				   entity.ParticipantOne != null && entity.ParticipantOne.Matches(request.ParticipantOne) &&
				   entity.ParticipantTwo != null && entity.ParticipantTwo.Matches(request.ParticipantTwo) &&
				   entity.CreatedAtUtc == request.CreatedAtUtc;
		}
	}

	extension(ChatId p)
	{
		public bool Matches(string participantOneId, string participantTwoId)
		{
			return p.ParticipantOneId.Id.EqualsOrdinalIgnoreCase(participantOneId) &&
				   p.ParticipantTwoId.Id.EqualsOrdinalIgnoreCase(participantTwoId);
		}
	}
}
