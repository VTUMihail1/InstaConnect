using InstaConnect.Business.Models.DTOs.Token;

namespace InstaConnect.Data.Abstraction.Helpers
{
    public interface ITokenManager
    {
        Task<TokenResultDTO> GenerateAccessToken(string userId);

        Task<TokenResultDTO> GenerateEmailConfirmationToken(string userId);

        Task<TokenResultDTO> GeneratePasswordResetToken(string userId);
        Task<TokenResultDTO> GetByValueAsync(string value);
        Task<bool> RemoveAsync(string value);
    }
}