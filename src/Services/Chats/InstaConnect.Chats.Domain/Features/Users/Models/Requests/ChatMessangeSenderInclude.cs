using InstaConnect.Chats.Domain.Features.Common.Models.Requests;
using InstaConnect.Common.Domain.Features.Data.Abstractions;

namespace InstaConnect.Chats.Domain.Features.Users.Models.Requests;

public record ChatMessangeSenderInclude(ICollection<ChatsIncludeDescriptor> Descriptors)
    : IInclude<ChatsDestinationType, ChatsIncludeType, ChatsIncludeDescriptor>;
