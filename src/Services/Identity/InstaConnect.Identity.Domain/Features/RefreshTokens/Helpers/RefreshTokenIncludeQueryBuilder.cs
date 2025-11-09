namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;

public class RefreshTokenIncludeQueryBuilder
{
    private readonly ICollection<RefreshTokenIncludeProperty> _includeProperties;

    internal RefreshTokenIncludeQueryBuilder(ICollection<RefreshTokenIncludeProperty> includeProperties)
    {
        _includeProperties = includeProperties;
    }

    public RefreshTokenIncludeQuery Build()
    {
        return new RefreshTokenIncludeQuery(_includeProperties);
    }
}
