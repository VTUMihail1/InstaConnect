using InstaConnect.Chats.Domain.Features.ChatMessages.Models.ValueObjects;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Users.Utilities;
using InstaConnect.Common.Domain.Features.Common.Extensions;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageEquals
{
	extension(ChatMessageAddedNotificationRequest request)
	{
		public bool Matches(ChatMessage entity)
		{
			return entity.Matches(request.ChatMessage);
		}
	}

	extension(ChatMessageUpdatedNotificationRequest request)
	{
		public bool Matches(ChatMessage entity)
		{
			return entity.Matches(request.ChatMessage);
		}
	}

	extension(ChatMessageDeletedNotificationRequest request)
	{
		public bool Matches(ChatMessage entity)
		{
			return entity.Matches(request.ChatMessage);
		}
	}

	extension(ChatMessage entity)
	{
		public bool Matches(ChatMessageNotificationRequest request)
		{
			return entity.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId, request.MessageId) &&
				   entity.Sender != null && entity.Sender.Matches(request.Sender) &&
				   entity.Chat != null && entity.Chat.Matches(request.Chat) &&
				   entity.Content == request.Content &&
				   entity.CreatedAtUtc == request.CreatedAtUtc &&
				   entity.UpdatedAtUtc == request.UpdatedAtUtc;
		}
	}

	extension(ChatMessageId p)
	{
		public bool Matches(string participantOneId, string participantTwoId, string messageId)
		{
			return p.Id.Matches(participantOneId, participantTwoId) &&
				   p.MessageId.EqualsOrdinalIgnoreCase(messageId);
		}
	}
}
