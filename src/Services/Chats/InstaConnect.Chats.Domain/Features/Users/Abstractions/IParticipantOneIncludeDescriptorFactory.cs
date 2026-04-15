using InstaConnect.Chats.Domain.Models.Requests;

namespace InstaConnect.Chats.Domain.Features.Users.Abstractions;

public interface IParticipantOneIncludeDescriptorFactory
{
    ChatsIncludeDescriptor CreateChatMessages();
    ChatsIncludeDescriptor CreateChats();
}