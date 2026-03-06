namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenCommandService
{
    public Task<EmailConfirmationToken> AddAsync(AddEmailConfirmationTokenCommand command, CancellationToken cancellationToken);

    public Task VerifyAsync(VerifyEmailConfirmationTokenCommand command, CancellationToken cancellationToken);
}
