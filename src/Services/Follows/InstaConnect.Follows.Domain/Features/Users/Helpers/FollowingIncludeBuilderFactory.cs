namespace InstaConnect.Follows.Domain.Features.Users.Helpers;

public class FollowingIncludeBuilderFactory : IFollowingIncludeBuilderFactory
{
    private readonly IFollowingIncludeDescriptorFactory _descriptorFactory;

    public FollowingIncludeBuilderFactory(IFollowingIncludeDescriptorFactory descriptorFactory)
    {
        _descriptorFactory = descriptorFactory;
    }

    public FollowingIncludeBuilder Create()
    {
        return new FollowingIncludeBuilder([], _descriptorFactory);
    }
}
