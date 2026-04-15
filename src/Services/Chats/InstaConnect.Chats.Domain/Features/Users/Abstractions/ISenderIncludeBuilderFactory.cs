using InstaConnect.Chats.Domain.Features.Users.Helpers;

namespace InstaConnect.Chats.Domain.Features.Users.Abstractions;

public interface ISenderIncludeBuilderFactory
{
    SenderIncludeBuilder Create();
}