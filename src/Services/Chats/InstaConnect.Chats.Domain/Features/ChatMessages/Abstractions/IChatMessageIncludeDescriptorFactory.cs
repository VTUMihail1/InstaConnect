using InstaConnect.Chats.Domain.Models.Requests;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

public interface IChatMessageIncludeDescriptorFactory
{
    ChatsIncludeDescriptor CreateChat();
    ChatsIncludeDescriptor CreateSender();
}
