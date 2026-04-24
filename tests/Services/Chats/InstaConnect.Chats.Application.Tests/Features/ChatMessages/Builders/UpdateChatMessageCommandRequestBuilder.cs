namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Builders;

public class UpdateChatMessageCommandRequestBuilder
{
    private string _participantOneId;
    private string _participantTwoId;
    private string _messageId;
    private string _content;

    public UpdateChatMessageCommandRequestBuilder(ChatMessage chatMessage)
    {
        _participantOneId = chatMessage.Id.Id.ParticipantOneId.Id;
        _participantTwoId = chatMessage.Id.Id.ParticipantTwoId.Id;
        _messageId = chatMessage.Id.MessageId;
        _content = ChatMessageDataFaker.GetContent();
    }

    public UpdateChatMessageCommandRequestBuilder WithParticipantOneId(UserId participantOneId, IStringTransformer? transformer = null)
    {
        _participantOneId = transformer.TryTransform(participantOneId.Id);

        return this;
    }

    public UpdateChatMessageCommandRequestBuilder WithParticipantOneId(IStringTransformer transformer)
    {
        _participantOneId = transformer.Transform(_participantOneId);

        return this;
    }

    public UpdateChatMessageCommandRequestBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
    {
        _participantTwoId = transformer.TryTransform(participantTwoId.Id);

        return this;
    }

    public UpdateChatMessageCommandRequestBuilder WithParticipantTwoId(IStringTransformer transformer)
    {
        _participantTwoId = transformer.Transform(_participantTwoId);

        return this;
    }

    public UpdateChatMessageCommandRequestBuilder WithMessageId(ChatMessageId messageId, IStringTransformer? transformer = null)
    {
        _messageId = transformer.TryTransform(messageId.MessageId);

        return this;
    }

    public UpdateChatMessageCommandRequestBuilder WithMessageId(IStringTransformer transformer)
    {
        _messageId = transformer.Transform(_messageId);

        return this;
    }

    public UpdateChatMessageCommandRequestBuilder WithContent(IStringTransformer transformer)
    {
        _content = transformer.Transform(_content);

        return this;
    }

    public UpdateChatMessageCommandRequest Build()
    {
        return new(_participantOneId, _participantTwoId, _messageId, _content);
    }
}
