using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Response;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Users.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenRepository
{
    Task<EmailConfirmationTokenCollection> GetAllAsync(GetAllEmailConfirmationTokensQuery query, CancellationToken cancellationToken);
    Task<EmailConfirmationToken?> GetByIdAsync(string id, string value, CancellationToken cancellationToken);

    void Add(EmailConfirmationToken emailConfirmationToken);

    void Delete(EmailConfirmationToken emailConfirmationToken);

    void DeleteRange(ICollection<EmailConfirmationToken> emailConfirmationTokens);
}
