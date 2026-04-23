using InstaConnect.Chats.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Chats.Domain.Features.Users.Models.Requests;

public record ParticipantOneInclude(ICollection<ChatsIncludeDescriptor> Descriptors)
    : IInclude<ChatsDestinationType, ChatsIncludeType, ChatsIncludeDescriptor>;
