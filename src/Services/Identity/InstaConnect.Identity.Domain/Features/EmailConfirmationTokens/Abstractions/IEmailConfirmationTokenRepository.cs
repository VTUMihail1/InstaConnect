namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenRepository
{
    Task<EmailConfirmationToken?> GetByIdAsync(
        string id,
        string value,
        EmailConfirmationTokenIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<EmailConfirmationToken?> GetByIdAsync(
        string id,
        string value,
        CancellationToken cancellationToken);

    Task AddAsync(EmailConfirmationToken entity, CancellationToken cancellationToken);

    Task DeleteRangeAsync(IEnumerable<EmailConfirmationToken> entities, CancellationToken cancellationToken);
}
