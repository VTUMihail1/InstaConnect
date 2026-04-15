using InstaConnect.Chats.Domain.Models.Requests;

namespace InstaConnect.Chats.Domain.Features.Users.Abstractions;

public interface IUserIncludeDescriptorFactory
{
    ChatsIncludeDescriptor CreateChats();

    ChatsIncludeDescriptor CreateChatMessages();
}
