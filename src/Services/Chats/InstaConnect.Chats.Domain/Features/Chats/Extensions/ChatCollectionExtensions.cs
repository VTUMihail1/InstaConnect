namespace InstaConnect.Chats.Domain.Features.Chats.Extensions;

public static class ChatCollectionExtensions
{
	extension(ICollection<Chat> chats)
	{
		public ICollection<Chat> AddParticipantOne(User participantOne)
		{
			foreach (var chat in chats)
			{
				chat.AddParticipantOne(participantOne);
			}

			return chats;
		}

		public ICollection<Chat> AddFollowing(User participantTwo)
		{
			foreach (var chat in chats)
			{
				chat.AddParticipantTwo(participantTwo);
			}

			return chats;
		}
	}
}
