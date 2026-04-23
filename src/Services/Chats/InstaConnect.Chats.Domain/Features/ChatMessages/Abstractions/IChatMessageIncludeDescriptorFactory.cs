using InstaConnect.Chats.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

public interface IChatMessageIncludeDescriptorFactory
{
    ChatsIncludeDescriptor CreateChat();
    ChatsIncludeDescriptor CreateSender();
}
