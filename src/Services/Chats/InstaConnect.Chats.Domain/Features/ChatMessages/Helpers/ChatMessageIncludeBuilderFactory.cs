namespace InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;

public class ChatMessageIncludeBuilderFactory : IChatMessageIncludeBuilderFactory
{
	private readonly IChatMessageIncludeDescriptorFactory _descriptorFactory;

	public ChatMessageIncludeBuilderFactory(IChatMessageIncludeDescriptorFactory descriptorFactory)
	{
		_descriptorFactory = descriptorFactory;
	}

	public ChatMessageIncludeBuilder Create()
	{
		return new ChatMessageIncludeBuilder([], _descriptorFactory);
	}
}
