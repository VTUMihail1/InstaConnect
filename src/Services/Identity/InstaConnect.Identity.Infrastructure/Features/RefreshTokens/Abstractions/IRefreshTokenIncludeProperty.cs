namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenIncludeProperty : IIncluder<RefreshToken>
{
    public RefreshTokenIncludeProperty IncludeProperty { get; }
}
