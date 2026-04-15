namespace InstaConnect.Chats.Domain.Features.Users.Helpers;

public class SenderIncludeBuilderFactory : ISenderIncludeBuilderFactory
{
    private readonly ISenderIncludeDescriptorFactory _descriptorFactory;

    public SenderIncludeBuilderFactory(ISenderIncludeDescriptorFactory descriptorFactory)
    {
        _descriptorFactory = descriptorFactory;
    }

    public SenderIncludeBuilder Create()
    {
        return new SenderIncludeBuilder([], _descriptorFactory);
    }
}
