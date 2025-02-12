using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entitites;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
public interface IEmailConfirmationTokenWriteRepository
{
    void Add(EmailConfirmationToken emailConfirmationToken);
    void Delete(EmailConfirmationToken emailConfirmationToken);
    Task<EmailConfirmationToken?> GetByValueAsync(string value, CancellationToken cancellationToken);
}
