using InstaConnect.Users.Business.Models;

namespace EGames.Business.Services
{
    public interface ITokenService
    {
        Task DeleteAsync(string value);
        Task<TokenViewModel> GenerateAccessTokenAsync(string userId);
        Task<TokenViewModel> GenerateEmailConfirmationTokenAsync(string userId);
        Task<TokenViewModel> GetByValueAsync(string value);
    }
}