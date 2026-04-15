using InstaConnect.Chats.Domain.Models.Requests;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record ChatMessageSenderInclude(ICollection<ChatsIncludeDescriptor> Descriptors)
    : IInclude<ChatsDestinationType, ChatsIncludeType, ChatsIncludeDescriptor>;
