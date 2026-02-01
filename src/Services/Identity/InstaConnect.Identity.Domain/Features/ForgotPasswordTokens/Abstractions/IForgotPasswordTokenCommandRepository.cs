namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenCommandRepository
{
    Task<ForgotPasswordToken?> GetByIdAsync(
        ForgotPasswordTokenId id,
        ForgotPasswordTokenInclude? include,
        CancellationToken cancellationToken);

    Task<ForgotPasswordToken?> GetByIdAsync(
        ForgotPasswordTokenId id,
        CancellationToken cancellationToken);

    Task AddAsync(ForgotPasswordToken entity, CancellationToken cancellationToken);

    Task DeleteRangeAsync(IEnumerable<ForgotPasswordToken> entities, CancellationToken cancellationToken);
}
