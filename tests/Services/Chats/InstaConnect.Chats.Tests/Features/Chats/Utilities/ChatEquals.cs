using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;
using InstaConnect.Common.Domain.Features.Common.Extensions;

namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public static class ChatEquals
{
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
