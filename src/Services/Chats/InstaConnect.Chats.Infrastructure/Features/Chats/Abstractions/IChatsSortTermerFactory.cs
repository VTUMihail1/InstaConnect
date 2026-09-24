using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

internal interface IChatsSortTermerFactory : ISortTermerFactory<ChatsSortTerm, IChatsSortTermer, ChatResponse>;
