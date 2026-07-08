using InstaConnect.Chats.Domain.Features.Chats.Models.ValueObjects;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Users.Utilities;

namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public static class ChatMapper
{
	extension(Chat chat)
	{
		public ChatId ToId()
		{
			return chat.Id;
		}

		public Chat ToFull()
		{
			return new Chat(chat.Id,
					   chat.CreatedAtUtc)
				.AddParticipantOne(chat.ParticipantOne?.ToFull())
				.AddParticipantTwo(chat.ParticipantTwo?.ToFull());
		}

		public Chat ToWithoutParticipantOne()
		{
			return new Chat(chat.Id,
					   chat.CreatedAtUtc)
				.AddParticipantTwo(chat.ParticipantTwo?.ToFull());
		}

		public Chat ToWithoutParticipantTwo()
		{
			return new Chat(chat.Id,
					   chat.CreatedAtUtc)
				.AddParticipantOne(chat.ParticipantOne?.ToFull());
		}
	}
}
