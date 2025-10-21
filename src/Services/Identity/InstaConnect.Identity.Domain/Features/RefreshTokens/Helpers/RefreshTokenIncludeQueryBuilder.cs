using InstaConnect.RefreshTokens.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.RefreshTokens.Domain.Features.RefreshTokens.Models.Requests;

namespace InstaConnect.RefreshTokens.Domain.Features.RefreshTokens.Helpers;

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
