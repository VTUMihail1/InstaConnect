using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Helpers;

namespace InstaConnect.ChatMessages.Domain.Features.ChatMessages.Abstractions;

public interface IChatMessageIncludeQueryBuilderFactory
{
    ChatMessageIncludeQueryBuilder Create();
}