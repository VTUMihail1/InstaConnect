using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Models.Entitites;

namespace InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Abstractions;
public interface IEmailConfirmationTokenWriteRepository
{
    void Add(EmailConfirmationToken emailConfirmationToken);
    void Delete(EmailConfirmationToken emailConfirmationToken);
    Task<EmailConfirmationToken?> GetByValueAsync(string value, CancellationToken cancellationToken);
}
