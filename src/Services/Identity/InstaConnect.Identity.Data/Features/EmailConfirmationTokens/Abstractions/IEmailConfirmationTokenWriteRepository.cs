using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Models.Entitites;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenWriteRepository : IBaseWriteRepository<EmailConfirmationToken>
{
    Task<EmailConfirmationToken?> GetByValueAsync(string value, CancellationToken cancellationToken);
}
