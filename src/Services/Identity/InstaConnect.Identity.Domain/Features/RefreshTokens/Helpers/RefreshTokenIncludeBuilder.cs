namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;

public class RefreshTokenIncludeBuilder
{
    private readonly HashSet<RefreshTokenIncludeProperty> _includeProperties;

    internal RefreshTokenIncludeBuilder(ICollection<RefreshTokenIncludeProperty> includeProperties)
    {
        _includeProperties = [.. includeProperties];
    }

    public RefreshTokenInclude Build()
    {
        return new(_includeProperties);
    }
}
