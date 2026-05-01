namespace InstaConnect.Chats.Tests.Features.Chats.Utilities;

public static class ChatGenerator
{
	extension(Chat baseChat)
	{
		public ICollection<Chat> Generate(IEnumerable<User> participantOnes, IEnumerable<User> participantTwos)
		{
			return [.. participantOnes
			  .SelectMany(participantOne =>
				  participantTwos.Select(participantTwo =>
				  {
					  var chat = new Chat(
						  new(participantOne.Id, participantTwo.Id),
						  ChatDataFaker.GetCreatedAtUtc());

					  if(baseChat.Id == chat.Id)
					  {
						  return baseChat;
					  }

					  participantOne.AddChat(chat);
					  participantTwo.AddChat(chat);
					  chat.AddParticipantOne(participantOne);
					  chat.AddParticipantTwo(participantTwo);

					  return chat;
				  }))];
		}
	}
}
