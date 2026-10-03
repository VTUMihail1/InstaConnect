using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessagesSortTermer : ISortTermer<ChatMessagesSortTerm, ChatMessageResponse>;
