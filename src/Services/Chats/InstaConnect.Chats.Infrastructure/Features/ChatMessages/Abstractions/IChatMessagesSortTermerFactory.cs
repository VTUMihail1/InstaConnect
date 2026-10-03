using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessagesSortTermerFactory : ISortTermerFactory<ChatMessagesSortTerm, IChatMessagesSortTermer, ChatMessageResponse>;
