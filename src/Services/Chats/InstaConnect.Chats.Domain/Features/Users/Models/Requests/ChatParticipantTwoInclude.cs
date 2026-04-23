using InstaConnect.Chats.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Chats.Domain.Features.Users.Models.Requests;

public record ChatParticipantTwoInclude(ICollection<ChatsIncludeDescriptor> Descriptors)
    : IInclude<ChatsDestinationType, ChatsIncludeType, ChatsIncludeDescriptor>;
