namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenCommandService
{
    public Task<ForgotPasswordTokenId> AddAsync(AddForgotPasswordTokenCommand command, CancellationToken cancellationToken);

    public Task VerifyAsync(VerifyForgotPasswordTokenCommand command, CancellationToken cancellationToken);
}
