namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public static class ChatReference
{
	extension(ICollection<Chat> chats)
	{
		public ICollection<Chat> SetParticipantOne()
		{
			foreach(var chat in chats)
			{
				chat.SetParticipantOne();
			}

			return chats;
		}

		public ICollection<Chat> SetParticipantTwo()
		{
			foreach (var chat in chats)
			{
				chat.SetParticipantTwo();
			}

			return chats;
		}
	}

	extension(Chat? chat)
	{
		public Chat? SetParticipantOne()
		{
			chat?.ParticipantOne?.AddChat(chat);

			return chat;
		}

		public Chat? SetParticipantTwo()
		{
			chat?.ParticipantTwo?.AddChat(chat);

			return chat;
		}
	}
}
