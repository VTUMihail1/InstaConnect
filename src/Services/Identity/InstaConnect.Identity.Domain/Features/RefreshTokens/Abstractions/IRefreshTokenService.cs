namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
public interface IRefreshTokenService
{
    public Task<SessionToken> IssueAsync(IssueRefreshTokenCommand command, CancellationToken cancellationToken);

    public Task<SessionToken> RotateAsync(RotateRefreshTokenCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeleteRefreshTokenCommand command, CancellationToken cancellationToken);
}
