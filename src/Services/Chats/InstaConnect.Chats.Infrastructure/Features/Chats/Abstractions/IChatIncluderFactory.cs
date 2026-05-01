using InstaConnect.Chats.Domain.Features.Common.Models.Requests;
using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

internal interface IChatIncluderFactory
	: IIncluderFactory<ChatsIncludeType, ChatsDestinationType, ChatsIncludeDescriptor, IChatIncluder, Chat>;

