using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

internal interface IChatMessagesSortTermerFactory : ISortTermerFactory<ChatMessagesSortTerm, IChatMessagesSortTermer, ChatMessageResponse>;
