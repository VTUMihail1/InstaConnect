using InstaConnect.Chats.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;

public class ChatMessageIncludeDescriptorFactory : IChatMessageIncludeDescriptorFactory
{
    public ChatsIncludeDescriptor CreateSender()
    {
        return new(ChatsDestinationType.ChatMessage, ChatsIncludeType.Sender);
    }

    public ChatsIncludeDescriptor CreateChat()
    {
        return new(ChatsDestinationType.ChatMessage, ChatsIncludeType.Chat);
    }
}
