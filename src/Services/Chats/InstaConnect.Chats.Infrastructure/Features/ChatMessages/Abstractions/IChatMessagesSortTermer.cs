using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

internal interface IChatMessagesSortTermer : ISortTermer<ChatMessagesSortTerm, ChatMessageResponse>;
