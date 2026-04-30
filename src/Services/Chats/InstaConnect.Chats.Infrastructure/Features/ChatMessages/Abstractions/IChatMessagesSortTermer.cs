using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

internal interface IChatMessagesSortTermer : ISortTermer<ChatMessagesSortTerm, ChatMessageResponse>;
