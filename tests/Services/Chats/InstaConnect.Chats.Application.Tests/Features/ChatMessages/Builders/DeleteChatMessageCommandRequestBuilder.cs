using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Builders;

public class DeleteChatMessageCommandRequestBuilder
{
    private string _participantOneId;
    private string _participantTwoId;
    private string _messageId;

    public DeleteChatMessageCommandRequestBuilder(ChatMessage chatMessage)
    {
        _participantOneId = chatMessage.Id.Id.ParticipantOneId.Id;
        _participantTwoId = chatMessage.Id.Id.ParticipantTwoId.Id;
        _messageId = chatMessage.Id.MessageId;
    }

    public DeleteChatMessageCommandRequestBuilder WithParticipantOneId(UserId participantOneId, IStringTransformer? transformer = null)
    {
        _participantOneId = transformer.TryTransform(participantOneId.Id);

        return this;
    }

    public DeleteChatMessageCommandRequestBuilder WithParticipantOneId(IStringTransformer transformer)
    {
        _participantOneId = transformer.Transform(_participantOneId);

        return this;
    }

    public DeleteChatMessageCommandRequestBuilder WithParticipantTwoId(UserId participantTwoId, IStringTransformer? transformer = null)
    {
        _participantTwoId = transformer.TryTransform(participantTwoId.Id);

        return this;
    }

    public DeleteChatMessageCommandRequestBuilder WithParticipantTwoId(IStringTransformer transformer)
    {
        _participantTwoId = transformer.Transform(_participantTwoId);

        return this;
    }

    public DeleteChatMessageCommandRequestBuilder WithMessageId(ChatMessageId messageId, IStringTransformer? transformer = null)
    {
        _messageId = transformer.TryTransform(messageId.MessageId);

        return this;
    }

    public DeleteChatMessageCommandRequestBuilder WithMessageId(IStringTransformer transformer)
    {
        _messageId = transformer.Transform(_messageId);

        return this;
    }

    public DeleteChatMessageCommandRequest Build()
    {
        return new(_participantOneId, _participantTwoId, _messageId);
    }
}
