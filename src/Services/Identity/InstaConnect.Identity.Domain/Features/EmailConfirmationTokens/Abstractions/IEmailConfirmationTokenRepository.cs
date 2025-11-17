namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenRepository
{
    Task<EmailConfirmationToken?> GetByIdAsync(
        EmailConfirmationTokenId id,
        EmailConfirmationTokenIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<EmailConfirmationToken?> GetByIdAsync(
        EmailConfirmationTokenId id,
        CancellationToken cancellationToken);

    Task AddAsync(EmailConfirmationToken entity, CancellationToken cancellationToken);

    Task DeleteRangeAsync(IEnumerable<EmailConfirmationToken> entities, CancellationToken cancellationToken);
}
