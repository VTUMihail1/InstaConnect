using InstaConnect.ForgotPasswordTokens.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;

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

    Task DeleteRangeAsync(ICollection<ForgotPasswordToken> entities, CancellationToken cancellationToken);
}
