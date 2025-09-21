using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenRepository
{
    Task<ForgotPasswordToken?> GetByIdAsync(string id, string value, CancellationToken cancellationToken);

    void Add(ForgotPasswordToken forgotPasswordToken);

    void Delete(ForgotPasswordToken forgotPasswordToken);
}
