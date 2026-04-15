namespace InstaConnect.Chats.Domain.Features.Chats.Helpers;

public class ChatIncludeBuilderFactory : IChatIncludeBuilderFactory
{
    private readonly IChatIncludeDescriptorFactory _descriptorFactory;

    public ChatIncludeBuilderFactory(IChatIncludeDescriptorFactory descriptorFactory)
    {
        _descriptorFactory = descriptorFactory;
    }

    public ChatIncludeBuilder Create()
    {
        return new ChatIncludeBuilder([], _descriptorFactory);
    }
}
