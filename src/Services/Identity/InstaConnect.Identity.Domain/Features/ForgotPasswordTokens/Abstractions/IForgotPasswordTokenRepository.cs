namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenRepository
{
    Task<ForgotPasswordToken?> GetByIdAsync(
        string id,
        string value,
        ForgotPasswordTokenIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<ForgotPasswordToken?> GetByIdAsync(
        string id,
        string value,
        CancellationToken cancellationToken);

    Task AddAsync(ForgotPasswordToken entity, CancellationToken cancellationToken);

    Task DeleteRangeAsync(IEnumerable<ForgotPasswordToken> entities, CancellationToken cancellationToken);
}
