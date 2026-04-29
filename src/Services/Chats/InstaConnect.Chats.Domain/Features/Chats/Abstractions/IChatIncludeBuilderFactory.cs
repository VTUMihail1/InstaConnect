using InstaConnect.Chats.Domain.Features.Chats.Helpers;

namespace InstaConnect.Chats.Domain.Features.Chats.Abstractions;

public interface IChatIncludeBuilderFactory
{
	public ChatIncludeBuilder Create();
}
