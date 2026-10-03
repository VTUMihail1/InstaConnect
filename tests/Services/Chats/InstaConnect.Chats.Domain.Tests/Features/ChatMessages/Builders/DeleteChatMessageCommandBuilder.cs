namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Builders;

public class DeleteChatMessageCommandBuilder
{
	private string _participantOneId;
	private string _participantTwoId;
	private string _messageId;

	public DeleteChatMessageCommandBuilder(ChatMessage chatMessage)
	{
		_participantOneId = chatMessage.Id.Id.ParticipantOneId.Id;
		_participantTwoId = chatMessage.Id.Id.ParticipantTwoId.Id;
		_messageId = chatMessage.Id.MessageId;
	}

	public DeleteChatMessageCommandBuilder WithParticipantOneId(UserId participantOneId, IStringTransformer? transformer = null)
	{
		_participantOneId = transformer.TryTransform(participantOneId.Id);

		return this;
	}

	public DeleteChatMessageCommandBuilder WithParticipantOneId(IStringTransformer transformer)
	{
		_participantOneId = transformer.Transform(_participantOneId);

		return this;
	}

	public DeleteChatMessageCommandBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
	{
		_participantTwoId = transformer.TryTransform(participantTwoId.Id);

		return this;
	}

	public DeleteChatMessageCommandBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public DeleteChatMessageCommandBuilder WithMessageId(ChatMessageId messageId, IStringTransformer? transformer = null)
	{
		_messageId = transformer.TryTransform(messageId.MessageId);

		return this;
	}

	public DeleteChatMessageCommandBuilder WithMessageId(IStringTransformer transformer)
	{
		_messageId = transformer.Transform(_messageId);

		return this;
	}

	public DeleteChatMessageCommand Build()
	{
		return new(
			new(
				new(
					new(_participantOneId),
					new(_participantTwoId)),
				_messageId));
	}
}
