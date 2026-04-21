using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Builders;

public class UpdateChatMessageApiRequestBuilder
{
    private string _participantOneId;
    private string _participantTwoId;
    private string _messageId;
    private string _content;

    public UpdateChatMessageApiRequestBuilder(ChatMessage chatMessage)
    {
        _participantOneId = chatMessage.Id.Id.ParticipantOneId.Id;
        _participantTwoId = chatMessage.Id.Id.ParticipantTwoId.Id;
        _messageId = chatMessage.Id.MessageId;
        _content = ChatMessageDataFaker.GetContent();
    }

    public UpdateChatMessageApiRequestBuilder WithParticipantOneId(UserId participantOneId, IStringTransformer? transformer = null)
    {
        _participantOneId = transformer.TryTransform(participantOneId.Id);

        return this;
    }

    public UpdateChatMessageApiRequestBuilder WithParticipantOneId(IStringTransformer transformer)
    {
        _participantOneId = transformer.Transform(_participantOneId);

        return this;
    }

    public UpdateChatMessageApiRequestBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
    {
        _participantTwoId = transformer.TryTransform(participantTwoId.Id);

        return this;
    }

    public UpdateChatMessageApiRequestBuilder WithParticipantTwoId(IStringTransformer transformer)
    {
        _participantTwoId = transformer.Transform(_participantTwoId);

        return this;
    }

    public UpdateChatMessageApiRequestBuilder WithMessageId(ChatMessageId messageId, IStringTransformer? transformer = null)
    {
        _messageId = transformer.TryTransform(messageId.MessageId);

        return this;
    }

    public UpdateChatMessageApiRequestBuilder WithMessageId(IStringTransformer transformer)
    {
        _messageId = transformer.Transform(_messageId);

        return this;
    }

    public UpdateChatMessageApiRequestBuilder WithContent(IStringTransformer transformer)
    {
        _content = transformer.Transform(_content);

        return this;
    }

    public UpdateChatMessageApiRequest Build()
    {
        return new(_participantOneId, _participantTwoId, _messageId, new(_content));
    }
}
