using InstaConnect.Chats.Domain.Features.Common.Models.Requests;
using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

internal interface IChatMessageIncluderFactory
	: IIncluderFactory<ChatsIncludeType, ChatsDestinationType, ChatsIncludeDescriptor, IChatMessageIncluder, ChatMessage>;
