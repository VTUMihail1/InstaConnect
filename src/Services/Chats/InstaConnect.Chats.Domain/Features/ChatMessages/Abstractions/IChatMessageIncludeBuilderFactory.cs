using InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Abstractions;

public interface IChatMessageIncludeBuilderFactory
{
    ChatMessageIncludeBuilder Create();
}
