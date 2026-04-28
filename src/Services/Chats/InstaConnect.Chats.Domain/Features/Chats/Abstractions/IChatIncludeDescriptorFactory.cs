using InstaConnect.Chats.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Chats.Domain.Features.Chats.Abstractions;

public interface IChatIncludeDescriptorFactory
{
    ChatsIncludeDescriptor CreateParticipantOne();
    ChatsIncludeDescriptor CreateParticipantTwo();
}
