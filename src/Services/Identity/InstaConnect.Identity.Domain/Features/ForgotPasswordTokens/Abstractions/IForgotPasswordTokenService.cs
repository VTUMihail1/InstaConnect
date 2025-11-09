namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
public interface IForgotPasswordTokenService
{
    public Task<ForgotPasswordToken> AddAsync(AddForgotPasswordTokenCommand command, CancellationToken cancellationToken);

    public Task VerifyAsync(VerifyForgotPasswordTokenCommand command, CancellationToken cancellationToken);
}
