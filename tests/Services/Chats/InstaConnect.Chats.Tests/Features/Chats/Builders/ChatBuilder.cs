using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Tests.Features.Chats.Builders;

public class ChatBuilder
{
	private readonly string _participantOneId;
	private readonly string _participantTwoId;
	private readonly User _participantOne;
	private readonly User _participantTwo;
	private readonly DateTimeOffset _createdAtUtc;

	public ChatBuilder(User participantOne, User participantTwo)
	{
		_participantOneId = participantOne.Id.Id;
		_participantTwoId = participantTwo.Id.Id;
		_participantOne = participantOne;
		_participantTwo = participantTwo;
		_createdAtUtc = ChatDataFaker.GetCreatedAtUtc();
	}

	public Chat Build()
	{
		var chat = new Chat(
				new(
					new(_participantOneId),
					new(_participantTwoId)),
				_createdAtUtc);

		chat.AddParticipantOne(_participantOne);
		chat.AddParticipantTwo(_participantTwo);
		_participantOne.AddChat(chat);
		_participantTwo.AddChat(chat);

		return chat;
	}
}
