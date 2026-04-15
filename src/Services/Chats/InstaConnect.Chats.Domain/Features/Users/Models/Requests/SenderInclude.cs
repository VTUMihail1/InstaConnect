using InstaConnect.Chats.Domain.Models.Requests;

namespace InstaConnect.Chats.Domain.Features.Users.Models.Requests;

public record SenderInclude(ICollection<ChatsIncludeDescriptor> Descriptors)
    : IInclude<ChatsDestinationType, ChatsIncludeType, ChatsIncludeDescriptor>;
