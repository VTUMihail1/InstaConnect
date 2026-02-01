namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenIncludePropertyFactory
    : IIncluderFactory<RefreshTokenIncludeProperty, IRefreshTokenIncludeProperty, RefreshToken>;
