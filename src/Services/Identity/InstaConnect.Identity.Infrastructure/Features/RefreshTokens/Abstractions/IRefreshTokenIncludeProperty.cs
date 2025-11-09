namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenIncludeProperty : IIncludeProperty<RefreshToken>
{
    public RefreshTokenIncludeProperty IncludeProperty { get; }
}
