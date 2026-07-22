namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public static class ChatReference
{
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
