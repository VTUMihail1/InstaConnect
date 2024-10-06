using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Models.Entitites;

namespace InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Abstractions;
public interface IForgotPasswordTokenWriteRepository
{
    void Add(ForgotPasswordToken forgotPasswordToken);
    void Delete(ForgotPasswordToken forgotPasswordToken);
    Task<ForgotPasswordToken?> GetByValueAsync(string value, CancellationToken cancellationToken);
}
