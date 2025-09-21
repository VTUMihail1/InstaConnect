using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
public interface IEmailConfirmationTokenService
{
    public Task<EmailConfirmationToken> AddAsync(AddEmailConfirmationTokenCommand command, CancellationToken cancellationToken);

    public Task VerifyAsync(VerifyEmailConfirmationTokenCommand command, CancellationToken cancellationToken);
}
