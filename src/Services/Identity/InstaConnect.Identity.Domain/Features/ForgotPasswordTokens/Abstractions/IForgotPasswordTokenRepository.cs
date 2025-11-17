namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenRepository
{
    Task<ForgotPasswordToken?> GetByIdAsync(
        ForgotPasswordTokenId id,
        ForgotPasswordTokenIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<ForgotPasswordToken?> GetByIdAsync(
        ForgotPasswordTokenId id,
        CancellationToken cancellationToken);

    Task AddAsync(ForgotPasswordToken entity, CancellationToken cancellationToken);

    Task DeleteRangeAsync(IEnumerable<ForgotPasswordToken> entities, CancellationToken cancellationToken);
}
