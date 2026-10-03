using InstaConnect.Chats.Domain.Features.Common.Models.Requests;
using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

public interface IChatIncluderFactory
	: IIncluderFactory<ChatsIncludeType, ChatsDestinationType, ChatsIncludeDescriptor, IChatIncluder, Chat>;

