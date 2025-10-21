using InstaConnect.Chats.Domain.Features.Chats.Helpers;

namespace InstaConnect.Chats.Domain.Features.Chats.Abstractions;

public interface IChatIncludeQueryBuilderFactory
{
    ChatIncludeQueryBuilder Create();
}