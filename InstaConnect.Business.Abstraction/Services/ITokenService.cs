using DocConnect.Business.Models.DTOs.Token;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.Results;

namespace InstaConnect.Business.Abstraction.Services
{
    public interface ITokenService
    {
        Task<IResult<TokenResultDTO>> AddAsync(TokenAddDTO tokenAddDTO);

        Task<IResult<TokenResultDTO>> GetByValueAsync(string value);

        Task<IResult<TokenResultDTO>> RemoveAsync(string value);

        IResult<TokenAddDTO> GenerateAccessToken(AccountResultDTO accountResultDTO);

        IResult<TokenAddDTO> GeneratePasswordResetToken(AccountResultDTO accountResultDTO);

        IResult<TokenAddDTO> GenerateEmailConfirmationToken(AccountResultDTO accountResultDTO);
    }
}