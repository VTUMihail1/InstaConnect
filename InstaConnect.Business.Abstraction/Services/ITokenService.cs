using InstaConnect.Business.Models.DTOs.Token;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    public interface ITokenService
    {
        Task<IResult<TokenResultDTO>> GenerateAccessTokenAsync(string userId);

        Task<IResult<TokenResultDTO>> GenerateEmailConfirmationTokenAsync(string userId);

        Task<IResult<TokenResultDTO>> GeneratePasswordResetTokenAsync(string userId);

        Task<IResult<TokenResultDTO>> GetByValueAsync(string value);

        Task<IResult<TokenResultDTO>> DeleteAsync(string value);
    }
}