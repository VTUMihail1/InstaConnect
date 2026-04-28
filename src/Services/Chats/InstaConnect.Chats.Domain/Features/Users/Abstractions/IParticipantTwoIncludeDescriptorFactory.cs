using InstaConnect.Chats.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Chats.Domain.Features.Users.Abstractions;

public interface IParticipantTwoIncludeDescriptorFactory
{
    ChatsIncludeDescriptor CreateChatMessages();
    ChatsIncludeDescriptor CreateChats();
}
