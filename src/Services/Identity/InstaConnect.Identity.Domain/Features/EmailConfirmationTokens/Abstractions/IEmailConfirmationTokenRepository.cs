using InstaConnect.EmailConfirmationTokens.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;

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

    Task DeleteRangeAsync(ICollection<EmailConfirmationToken> entities, CancellationToken cancellationToken);
}
