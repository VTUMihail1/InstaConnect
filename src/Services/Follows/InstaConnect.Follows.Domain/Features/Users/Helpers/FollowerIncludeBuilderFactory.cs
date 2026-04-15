namespace InstaConnect.Follows.Domain.Features.Users.Helpers;

public class FollowerIncludeBuilderFactory : IFollowerIncludeBuilderFactory
{
    private readonly IFollowerIncludeDescriptorFactory _descriptorFactory;

    public FollowerIncludeBuilderFactory(IFollowerIncludeDescriptorFactory descriptorFactory)
    {
        _descriptorFactory = descriptorFactory;
    }

    public FollowerIncludeBuilder Create()
    {
        return new FollowerIncludeBuilder([], _descriptorFactory);
    }
}
