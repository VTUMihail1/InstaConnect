using InstaConnect.Chats.Domain.Features.Common.Models.Requests;
using InstaConnect.Common.Domain.Features.Databases.Abstractions;

namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record ChatInclude(ICollection<ChatsIncludeDescriptor> Descriptors)
	: IInclude<ChatsDestinationType, ChatsIncludeType, ChatsIncludeDescriptor>;
