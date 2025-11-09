namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenIncludePropertyFactory
{
    IEnumerable<IRefreshTokenIncludeProperty> Create(ICollection<RefreshTokenIncludeProperty>? includeProperties);
}
