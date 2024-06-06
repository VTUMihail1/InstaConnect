using InstaConnect.Users.Business.Models;

namespace InstaConnect.Users.Business.Abstractions;

public interface ITokenService
{
    Task DeleteAsync(string value, CancellationToken cancellationToken);

    Task<TokenViewDTO> GenerateAccessTokenAsync(string userId, CancellationToken cancellationToken);

    Task<TokenViewDTO> GenerateEmailConfirmationTokenAsync(string userId, CancellationToken cancellationToken);

    Task<TokenViewDTO> GetByValueAsync(string value, CancellationToken cancellationToken);

    Task<TokenViewDTO> GeneratePasswordResetTokenAsync(string userId, CancellationToken cancellationToken);
}