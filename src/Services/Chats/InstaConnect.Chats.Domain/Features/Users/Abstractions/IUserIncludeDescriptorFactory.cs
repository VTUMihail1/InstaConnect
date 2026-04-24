using InstaConnect.Chats.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Chats.Domain.Features.Users.Abstractions;

public interface IUserIncludeDescriptorFactory
{
    ChatsIncludeDescriptor CreateChats();

    ChatsIncludeDescriptor CreateChatMessages();
}
