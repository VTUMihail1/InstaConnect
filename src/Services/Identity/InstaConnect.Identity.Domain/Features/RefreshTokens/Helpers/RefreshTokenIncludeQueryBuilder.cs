using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;

public class RefreshTokenIncludeQueryBuilder
{
    private readonly ICollection<RefreshTokenIncludeProperty> _includeProperties;

    internal RefreshTokenIncludeQueryBuilder(ICollection<RefreshTokenIncludeProperty> includeProperties)
    {
        _includeProperties = includeProperties;
    }

    public CommonIncludeQuery<RefreshTokenIncludeProperty> Build()
    {
        return new(_includeProperties);
    }
}
