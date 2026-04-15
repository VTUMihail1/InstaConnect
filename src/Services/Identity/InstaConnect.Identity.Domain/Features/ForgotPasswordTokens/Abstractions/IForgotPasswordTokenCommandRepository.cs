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

    Task<bool> ExistsByIdAsync(
        ForgotPasswordTokenId id,
        CancellationToken cancellationToken);

    Task AddAsync(ForgotPasswordToken entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<ForgotPasswordToken> entities, CancellationToken cancellationToken);

    Task UpdateAsync(ForgotPasswordToken entity, CancellationToken cancellationToken);

    Task DeleteAsync(ForgotPasswordToken entity, CancellationToken cancellationToken);

    Task DeleteRangeAsync(IEnumerable<ForgotPasswordToken> entities, CancellationToken cancellationToken);
}
