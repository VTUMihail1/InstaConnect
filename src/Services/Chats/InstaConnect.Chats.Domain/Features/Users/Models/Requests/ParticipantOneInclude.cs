using InstaConnect.Chats.Domain.Features.Common.Models.Requests;
using InstaConnect.Common.Domain.Features.Databases.Abstractions;

namespace InstaConnect.Chats.Domain.Features.Users.Models.Requests;

public record ParticipantOneInclude(ICollection<ChatsIncludeDescriptor> Descriptors)
	: IInclude<ChatsDestinationType, ChatsIncludeType, ChatsIncludeDescriptor>;
