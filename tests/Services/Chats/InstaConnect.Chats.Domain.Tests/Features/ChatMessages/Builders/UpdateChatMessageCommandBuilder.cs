namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Builders;

public class UpdateChatMessageCommandBuilder
{
	private string _participantOneId;
	private string _participantTwoId;
	private string _messageId;
	private string _content;

	public UpdateChatMessageCommandBuilder(ChatMessage chatMessage)
	{
		_participantOneId = chatMessage.Id.Id.ParticipantOneId.Id;
		_participantTwoId = chatMessage.Id.Id.ParticipantTwoId.Id;
		_messageId = chatMessage.Id.MessageId;
		_content = ChatMessageDataFaker.GetContent();
	}

	public UpdateChatMessageCommandBuilder WithParticipantOneId(UserId participantOneId, IStringTransformer? transformer = null)
	{
		_participantOneId = transformer.TryTransform(participantOneId.Id);

		return this;
	}

	public UpdateChatMessageCommandBuilder WithParticipantOneId(IStringTransformer transformer)
	{
		_participantOneId = transformer.Transform(_participantOneId);

		return this;
	}

	public UpdateChatMessageCommandBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
	{
		_participantTwoId = transformer.TryTransform(participantTwoId.Id);

		return this;
	}

	public UpdateChatMessageCommandBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public UpdateChatMessageCommandBuilder WithMessageId(ChatMessageId messageId, IStringTransformer? transformer = null)
	{
		_messageId = transformer.TryTransform(messageId.MessageId);

		return this;
	}

	public UpdateChatMessageCommandBuilder WithMessageId(IStringTransformer transformer)
	{
		_messageId = transformer.Transform(_messageId);

		return this;
	}

	public UpdateChatMessageCommandBuilder WithContent(IStringTransformer transformer)
	{
		_content = transformer.Transform(_content);

		return this;
	}

	public UpdateChatMessageCommand Build()
	{
		return new(
			new(
				new(
					new(_participantOneId),
					new(_participantTwoId)),
				_messageId),
			_content);
	}
}
