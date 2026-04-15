using InstaConnect.Chats.Domain.Models.Requests;

namespace InstaConnect.Chats.Domain.Features.Users.Abstractions;

public interface IParticipantTwoIncludeDescriptorFactory
{
    ChatsIncludeDescriptor CreateChatMessages();
    ChatsIncludeDescriptor CreateChats();
}