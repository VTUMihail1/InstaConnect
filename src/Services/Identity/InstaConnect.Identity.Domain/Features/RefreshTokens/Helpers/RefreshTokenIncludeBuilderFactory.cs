namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;

public class RefreshTokenIncludeBuilderFactory : IRefreshTokenIncludeBuilderFactory
{
    private readonly IRefreshTokenIncludeDescriptorFactory _descriptorFactory;

    public RefreshTokenIncludeBuilderFactory(IRefreshTokenIncludeDescriptorFactory descriptorFactory)
    {
        _descriptorFactory = descriptorFactory;
    }

    public RefreshTokenIncludeBuilder Create()
    {
        return new RefreshTokenIncludeBuilder([], _descriptorFactory);
    }
}
