namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenCommandRepository
{
    Task<EmailConfirmationToken?> GetByIdAsync(
        EmailConfirmationTokenId id,
        EmailConfirmationTokenInclude? include,
        CancellationToken cancellationToken);

    Task<EmailConfirmationToken?> GetByIdAsync(
        EmailConfirmationTokenId id,
        CancellationToken cancellationToken);

    Task AddAsync(EmailConfirmationToken entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<EmailConfirmationToken> entities, CancellationToken cancellationToken);

    Task DeleteAsync(EmailConfirmationToken entity, CancellationToken cancellationToken);

    Task DeleteRangeAsync(IEnumerable<EmailConfirmationToken> entities, CancellationToken cancellationToken);
}
