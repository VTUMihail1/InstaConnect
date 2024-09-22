using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Models.Entitites;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenWriteRepository : IBaseWriteRepository<ForgotPasswordToken>
{
    Task<ForgotPasswordToken?> GetByValueAsync(string value, CancellationToken cancellationToken);
}
