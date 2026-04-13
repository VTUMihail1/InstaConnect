using InstaConnect.Chats.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Builders;

public class ChatMessageBuilder
{
    private string _participantOneId;
    private string _participantTwoId;
    private Chat _chat;
    private string _messageId;
    private string _senderId;
    private User _sender;
    private string _content;
    private DateTimeOffset _createdAtUtc;
    private DateTimeOffset _updatedAtUtc;

    public ChatMessageBuilder(Chat chat)
    {
        _participantOneId = chat.Id.ParticipantOneId.Id;
        _participantTwoId = chat.Id.ParticipantTwoId.Id;
        _chat = chat;
        _messageId = ChatMessageDataFaker.GetId();
        _senderId = chat.Id.ParticipantOneId.Id;
        _sender = chat.ParticipantOne!;
        _content = ChatMessageDataFaker.GetContent();
        _createdAtUtc = ChatMessageDataFaker.GetCreatedAtUtc();
        _updatedAtUtc = ChatMessageDataFaker.GetUpdatedAtUtc();
    }

    public ChatMessageBuilder WithSenderId(UserId senderId)
    {
        _senderId = senderId.Id;

        return this;
    }

    public ChatMessage Build()
    {
        var chatMessage = new ChatMessage(
                new(
                    new(
                        new(_participantOneId),
                        new(_participantTwoId)),
                    _messageId),
                new(_senderId),
                _content,
                _createdAtUtc,
                _updatedAtUtc);

        _chat.AddChatMessage(chatMessage);
        _sender.AddChatMessage(chatMessage);
        chatMessage.AddChat(_chat);
        chatMessage.AddSender(_sender);

        return chatMessage;
    }
}
