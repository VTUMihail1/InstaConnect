namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Builders;

public class DeleteChatMessageApiRequestBuilder
{
	private string _participantOneId;
	private string _participantTwoId;
	private string _messageId;

	public DeleteChatMessageApiRequestBuilder(ChatMessage chatMessage)
	{
		_participantOneId = chatMessage.Id.Id.ParticipantOneId.Id;
		_participantTwoId = chatMessage.Id.Id.ParticipantTwoId.Id;
		_messageId = chatMessage.Id.MessageId;
	}

	public DeleteChatMessageApiRequestBuilder WithParticipantOneId(UserId participantOneId, IStringTransformer? transformer = null)
	{
		_participantOneId = transformer.TryTransform(participantOneId.Id);

		return this;
	}

	public DeleteChatMessageApiRequestBuilder WithParticipantOneId(IStringTransformer transformer)
	{
		_participantOneId = transformer.Transform(_participantOneId);

		return this;
	}

	public DeleteChatMessageApiRequestBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
	{
		_participantTwoId = transformer.TryTransform(participantTwoId.Id);

		return this;
	}

	public DeleteChatMessageApiRequestBuilder WithParticipantTwoId(IStringTransformer transformer)
	{
		_participantTwoId = transformer.Transform(_participantTwoId);

		return this;
	}

	public DeleteChatMessageApiRequestBuilder WithMessageId(ChatMessageId messageId, IStringTransformer? transformer = null)
	{
		_messageId = transformer.TryTransform(messageId.MessageId);

		return this;
	}

	public DeleteChatMessageApiRequestBuilder WithMessageId(IStringTransformer transformer)
	{
		_messageId = transformer.Transform(_messageId);

		return this;
	}

	public DeleteChatMessageApiRequest Build()
	{
		return new(_participantOneId, _participantTwoId, _messageId);
	}
}
