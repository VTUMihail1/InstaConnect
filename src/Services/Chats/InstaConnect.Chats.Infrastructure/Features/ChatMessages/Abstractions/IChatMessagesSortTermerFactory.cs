using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

internal interface IChatMessagesSortTermerFactory : ISortTermerFactory<ChatMessagesSortTerm, IChatMessagesSortTermer, ChatMessageResponse>;
