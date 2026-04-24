using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

internal interface IChatsSortTermerFactory : ISortTermerFactory<ChatsSortTerm, IChatsSortTermer, ChatResponse>;
