namespace InstaConnect.Follows.Domain.Features.Follows.Helpers;

public class FollowIncludeBuilderFactory : IFollowIncludeBuilderFactory
{
    private readonly IFollowIncludeDescriptorFactory _descriptorFactory;

    public FollowIncludeBuilderFactory(IFollowIncludeDescriptorFactory descriptorFactory)
    {
        _descriptorFactory = descriptorFactory;
    }

    public FollowIncludeBuilder Create()
    {
        return new FollowIncludeBuilder([], _descriptorFactory);
    }
}
